using UnityEngine;

[CreateAssetMenu(fileName = "DisplayDescriptionInteraction", menuName = "Museum/Interactions/Display Description")]
public class DisplayDescriptionInteraction : ScriptableObject, IInteraction
{
    public void PerformOn(IInteractable interactable)
    {
        if (interactable is not Description displayInfo) return;

        CanvasInfoDisplayer.Instance.Display(displayInfo.Text);
    }
}