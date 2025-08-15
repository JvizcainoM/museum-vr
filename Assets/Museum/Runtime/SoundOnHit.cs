using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundOnHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        var clip = AudioManager.Instance?.GetAudioClip(SoundType.HitSound);
        if (clip == null) return;
        var audioSource = GetComponent<AudioSource>();
        var magnitude = other.relativeVelocity.magnitude;
        audioSource.clip = clip;
        audioSource.pitch = Random.Range(0.8f, 1.2f) - (magnitude > 4f ? 0.3f : 0f);
        audioSource.volume = Mathf.InverseLerp(0f, 80f, magnitude);
        audioSource.Play();
    }
}