using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _player;
    public Vector3 offset;
    public bool invertZ = false;

    private void Start()
    {
        _player = Camera.main.transform;
    }

    private void Update()
    {
        var lookPos = _player.position - transform.position;
        if (invertZ)
        {
            lookPos = -lookPos;
        }
        var rotation = Quaternion.LookRotation(lookPos) * Quaternion.Euler(offset);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
}