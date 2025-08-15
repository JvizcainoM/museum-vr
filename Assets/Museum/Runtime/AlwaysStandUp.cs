using UnityEngine;

public class AlwaysStandUp : MonoBehaviour
{
    private void Update()
    {
        var euler = transform.rotation.eulerAngles;
        euler.x = 0f;
        euler.z = 0f;
        transform.rotation = Quaternion.Euler(euler);
    }
}