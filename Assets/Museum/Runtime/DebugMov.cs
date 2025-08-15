using UnityEngine;
using UnityEngine.InputSystem;

public class DebugMov : MonoBehaviour
{
    private bool _rotating;

    private void Update()
    {
        if (Mouse.current.middleButton.wasPressedThisFrame) _rotating = !_rotating;
        if (!_rotating) return;
        var t = Mathf.Sin(Time.time * 0.03f);
        var rot = Vector3.one * (t * 10f);
        transform.rotation *= Quaternion.Euler(rot);
    }
}