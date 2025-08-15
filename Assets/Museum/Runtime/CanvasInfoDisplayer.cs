using DG.Tweening;
using TMPro;
using UnityEngine;

public class CanvasInfoDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText;
    public static CanvasInfoDisplayer Instance { get; private set; }
    private CanvasGroup _canvasGroup;
    private VideoPlayerController _videoPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _canvasGroup = GetComponent<CanvasGroup>();
            _videoPlayer = GetComponentInChildren<VideoPlayerController>();
            _canvasGroup.alpha = 0f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Display(string text)
    {
        descriptionText.text = text;
        _canvasGroup.DOFade(1f, 0.5f)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => { _videoPlayer.CanUse = true; });
    }

    public void Hide()
    {
        _videoPlayer.CanUse = false;
        _canvasGroup.DOFade(0f, 0.5f)
            .SetEase(Ease.OutCubic);
    }
}