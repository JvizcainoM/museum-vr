using UnityEngine;

[CreateAssetMenu(fileName = "GrabInteraction", menuName = "Museum/Interactions/Grab Interaction")]
public class GrabInteraction : ScriptableObject, IInteraction
{
    public FixedJoint Holder { get; set; }

    public void PerformOn(IInteractable interactable)
    {
        if (interactable is not Grabbable grabbable)
            return;

        if (grabbable.IsGrabbed) return;

        grabbable.IsGrabbed = true;
        var rb = grabbable.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        Holder.connectedBody = rb;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
}