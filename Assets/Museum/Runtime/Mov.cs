using UnityEngine;
using UnityEngine.InputSystem;

public class Mov : MonoBehaviour
{
    private bool rotating = false;

    private void Update()
    {
        var t = Mathf.Sin(Time.time * 3f);

        var pos = transform.position;
        pos.y = Mathf.Lerp(0f, 2.1f, (t + 1) / 2);
        pos.x = Mathf.Lerp(-1f, 1f, (t + 1) / 2);
        transform.position = pos;

        if (Mouse.current.middleButton.wasPressedThisFrame) rotating = !rotating;
        if (!rotating) return;
        var rot = Vector3.one * 5;
        transform.rotation *= Quaternion.Euler(rot);
    }
}