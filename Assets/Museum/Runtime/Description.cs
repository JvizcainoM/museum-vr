using UnityEngine;

public class Description : MonoBehaviour, IInteractable
{
    [TextArea] public string infoText;
    public string Text => infoText;

    public void Accept(IInteraction interaction)
    {
        interaction?.PerformOn(this);
    }
}