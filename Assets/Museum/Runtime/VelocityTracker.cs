using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
    public Vector3 Velocity { get; private set; }
    public Vector3 AngularVelocity { get; private set; }

    private Vector3 _lastPosition;
    private Quaternion _lastRotation;

    private void Start()
    {
        _lastPosition = transform.position;
        _lastRotation = transform.rotation;
    }

    private void Update()
    {
        var currentPosition = transform.position;
        Velocity = (currentPosition - _lastPosition) / Time.deltaTime;
        _lastPosition = currentPosition;

        var currentRotation = transform.rotation;
        var deltaRotation = currentRotation * Quaternion.Inverse(_lastRotation);
        deltaRotation.ToAngleAxis(out var angle, out var axis);
        AngularVelocity = axis * (Mathf.Deg2Rad * angle) / Time.deltaTime;
        _lastRotation = currentRotation;
    }
}