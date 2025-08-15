using UnityEngine;

public class ParticlesOnHit : MonoBehaviour
{
    public Vector3 rotationOffset;
    public string hitParticleResourcePath = "FX_DirtSplatter";
    private ParticleFactory _particleFactory;

    private void Awake()
    {
        _particleFactory = new ParticleFactory();
    }

    private void OnCollisionEnter(Collision other)
    {
        var contact = other.contacts[0];
        var rotation = Quaternion.FromToRotation(Vector3.up, contact.normal) * Quaternion.Euler(rotationOffset);
        var position = contact.point;
        _particleFactory.GetParticleSystem(hitParticleResourcePath, position, rotation);
    }
}