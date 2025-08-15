using UnityEngine;

[CreateAssetMenu(fileName = "HideDescriptionInteraction", menuName = "Museum/Interactions/Hide Description")]
public class HideDescriptionInteraction : ScriptableObject, IInteraction
{
    public void PerformOn(IInteractable interactable)
    {
        if (interactable is not Description) return;
        CanvasInfoDisplayer.Instance.Hide();
    }
}