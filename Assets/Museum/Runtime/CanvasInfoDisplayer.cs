using Interpolations.Runtime.Core;
using TMPro;
using UnityEngine;

public class CanvasInfoDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Transform pivot;
    public static CanvasInfoDisplayer Instance { get; private set; }

    private FloatInterpolated _fadeAlpha;
    private Vector3Interpolated _fadePosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _fadeAlpha = new FloatInterpolated(0f);
            _fadeAlpha.SetEasing(Easings.EaseOutCubic).SetDuration(0.5f);
            _fadePosition = new Vector3Interpolated(pivot.position);
            _fadePosition.SetEasing(Easings.EaseOutCubic).SetDuration(0.5f);
            canvasGroup.alpha = 0f;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        canvasGroup.alpha = _fadeAlpha.GetValue();
    }

    private void LateUpdate()
    {
        pivot.position = _fadePosition.GetValue();
    }

    public void DisplayInfo(string text)
    {
        infoText.text = text;
        _fadeAlpha.SetValue(1f);
    }

    public void Hide()
    {
        _fadeAlpha.SetValue(0f);
    }
}