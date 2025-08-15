using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    HitSound,
}

public class AudioManager : MonoBehaviour
{
    public string hitSoundResourcePath = "Sounds/HitSound";
    public static AudioManager Instance { get; private set; }

    private List<AudioClip> _audioClips = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _audioClips.AddRange(Resources.LoadAll<AudioClip>(hitSoundResourcePath));
    }

    public AudioClip GetAudioClip(SoundType soundType)
    {
        if (soundType == SoundType.HitSound)
        {
            var randomIndex = Random.Range(0, _audioClips.Count);
            return _audioClips[randomIndex];
        }

        return null;
    }
}