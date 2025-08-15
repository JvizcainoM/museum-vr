using UnityEngine;

public class ParticleFactory
{
    public ParticleSystem GetParticleSystem(string resourcePath, Vector3 position, Quaternion rotation)
    {
        var prefab = Resources.Load<ParticleSystem>(resourcePath);
        if (prefab == null)
        {
            Debug.LogError($"Particle system prefab not found at path: {resourcePath}");
            return null;
        }

        var system = Object.Instantiate(prefab, position, rotation);
        system.Play();
        return system;
    }
}