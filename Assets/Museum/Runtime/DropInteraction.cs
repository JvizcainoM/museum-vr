using UnityEngine;

public class DropInteraction : MonoBehaviour
{
    [SerializeField] private FixedJoint holder;
    [SerializeField] private float throwForceFactor = 1f;

    public void Interact()
    {
        var grabbable = holder.connectedBody?.GetComponent<Grabbable>();
        if (grabbable == null) return;

        grabbable.Drop();
        var rb = grabbable.GetComponent<Rigidbody>();
        var velTracker = holder.GetComponent<VelocityTracker>();

        rb.linearVelocity = velTracker.Velocity * throwForceFactor;
        rb.angularVelocity = velTracker.AngularVelocity;
        holder.connectedBody = null;

        rb.interpolation = RigidbodyInterpolation.None;
        rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
    }
}