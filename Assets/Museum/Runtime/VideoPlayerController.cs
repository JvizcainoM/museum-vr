using DG.Tweening;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    public bool CanUse { get; set; }

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.localScale = Vector3.one;
        transform.DOShakeScale(0.5f, 0.1f)
            .OnComplete(() => transform.localScale = Vector3.one);
        if (!CanUse) return;
        if (_videoPlayer.isPlaying) _videoPlayer.Pause();
        else _videoPlayer.Play();
    }
}