public class Grabbable : InteractableObject
{
    public bool IsGrabbed { get; set; }

    public override void Accept(IInteraction interaction)
    {
        interaction?.PerformOn(this);
    }
}