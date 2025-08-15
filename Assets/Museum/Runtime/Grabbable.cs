using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool IsGrabbed { get; private set; }

    public void Grab()
    {
        if (IsGrabbed) return;
        IsGrabbed = true;

        var infoDisplay = GetComponent<InfoDisplay>();
        if (infoDisplay != null)
            infoDisplay.ShowInfo();
    }

    public void Drop()
    {
        if (!IsGrabbed) return;
        IsGrabbed = false;

        CanvasInfoDisplayer.Instance?.Hide();
    }
}