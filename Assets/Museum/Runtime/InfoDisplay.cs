using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
    [TextArea] public string infoText;

    public void ShowInfo()
    {
        CanvasInfoDisplayer.Instance.DisplayInfo(infoText);
    }
}