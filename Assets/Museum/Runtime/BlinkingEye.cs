using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BlinkingEye : MonoBehaviour
{
    private static readonly int Blink = Animator.StringToHash("Blink");
    private Animator _animator;
    private float _blinkTimer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _blinkTimer = Time.time + Random.Range(5, 12);
    }

    private void Update()
    {
        if (_blinkTimer > Time.time) return;
        _blinkTimer = Time.time + Random.Range(5, 12);
        _animator.SetTrigger(Blink);
    }
}