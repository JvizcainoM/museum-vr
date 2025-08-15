using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    [SerializeField] private float interactionRadius = 0.25f;

    private int _layerMask;
    private Grabbable _grabbable;
    private FixedJoint _holder;
    private readonly Collider[] _colliders = new Collider[1];

    private void Awake()
    {
        _holder = GetComponentInChildren<FixedJoint>();
    }

    private void Start()
    {
        _layerMask = LayerMask.GetMask("Things", "Treasures");
    }

    public void Interact()
    {
        var size = Physics.OverlapSphereNonAlloc(_holder.transform.position, interactionRadius, _colliders, _layerMask);
        Debug.Log(size);
        if (size == 0) return;

        _grabbable = _colliders[0].GetComponent<Grabbable>();
        if (_grabbable == null) return;
        if (_grabbable.IsGrabbed) return;

        _grabbable.Grab();
        var rb = _grabbable.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        _holder.connectedBody = rb;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (interactionRadius < 0.01f)
            interactionRadius = 0.01f;
        if (_holder == null)
            _holder = GetComponentInChildren<FixedJoint>();
    }

    private void OnDrawGizmosSelected()
    {
        if (_holder == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_holder.transform.position, interactionRadius);
        Gizmos.DrawLine(_holder.transform.position,
            _holder.transform.position + _holder.transform.forward * interactionRadius);
    }
#endif
}