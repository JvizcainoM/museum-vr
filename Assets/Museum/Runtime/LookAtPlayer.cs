using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform _player;
    public Vector3 offset;

    private void Start()
    {
        _player = Camera.main.transform;
    }

    private void Update()
    {
        var lookPos = _player.position - transform.position;
        var rotation = Quaternion.LookRotation(lookPos) * Quaternion.Euler(offset);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
    }
}