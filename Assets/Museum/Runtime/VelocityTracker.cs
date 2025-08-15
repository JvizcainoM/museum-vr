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
    }

    private void Update()
    {
        var currentPosition = transform.position;
        Velocity = (currentPosition - _lastPosition) / Time.deltaTime;
        _lastPosition = currentPosition;

        var currentRotation = transform.rotation;
        AngularVelocity = (currentRotation * Quaternion.Inverse(_lastRotation)).eulerAngles / Time.deltaTime;
        _lastRotation = currentRotation;
    }
}