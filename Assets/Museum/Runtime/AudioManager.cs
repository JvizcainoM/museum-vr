using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public string hitSoundResourcePath = "Sounds/HitSound";
    public string musicResourcePath = "Music";
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
        var musicSource = gameObject.AddComponent<AudioSource>();
        var musicClips = Resources.LoadAll<AudioClip>(musicResourcePath);
        if (musicClips.Length > 0)
        {
            var musicClip = musicClips[Random.Range(0, musicClips.Length)];
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.volume = 0.1f;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning($"Music clip not found at path: {musicResourcePath}");
        }
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