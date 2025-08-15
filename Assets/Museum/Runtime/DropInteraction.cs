using UnityEngine;

[CreateAssetMenu(fileName = "DropInteraction", menuName = "Museum/Interactions/Drop Interaction")]
public class DropInteraction : ScriptableObject, IInteraction
{
    public float throwForceFactor = 1f;
    public FixedJoint Holder { get; set; }

    public void PerformOn(IInteractable interactable)
    {
        if (interactable is not Grabbable grabbable) return;
        if (!grabbable.IsGrabbed) return;

        grabbable.IsGrabbed = false;
        var rb = grabbable.GetComponent<Rigidbody>();
        var velTracker = Holder.GetComponent<VelocityTracker>();
        var offsetVector = rb.transform.position - Holder.transform.position;
        var linealVelocityIncluded = Vector3.Cross(velTracker.AngularVelocity, offsetVector);

        rb.linearVelocity = (velTracker.Velocity + linealVelocityIncluded) * throwForceFactor;
        rb.angularVelocity = velTracker.AngularVelocity;
        Holder.connectedBody = null;

        rb.interpolation = RigidbodyInterpolation.None;
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }
}