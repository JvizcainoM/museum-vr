using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Museum.Runtime
{
    public class PlayerInputControl : MonoBehaviour
    {
        public UnityEvent onTriggerPressed;
        public UnityEvent onTriggerReleased;

        private void Update()
        {
#if UNITY_EDITOR && !UNITY_ANDROID

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log("Secondary Index Trigger Pressed");
                onTriggerPressed?.Invoke();
            }

            if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                Debug.Log("Secondary Index Trigger Released");
                onTriggerReleased?.Invoke();
            }
#elif UNITY_EDITOR && UNITY_ANDROID
#endif
        }
    }
}