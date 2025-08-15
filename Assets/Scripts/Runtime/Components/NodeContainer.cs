using Interpolations.Runtime.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Components
{
    public class NodeContainer : MonoBehaviour
    {
        private Vector2Interpolated _position;

        private void Awake()
        {
            _position = new Vector2Interpolated(Vector2.zero);
            _position.SetEasing(Easings.EaseOutElastic).SetDuration(1.2f);
        }

        private void Update()
        {
            if (!Keyboard.current.spaceKey.wasPressedThisFrame) return;
            var screenPoint = Mouse.current.position.ReadValue();
            var worldPoint =
                Camera.main.ScreenToWorldPoint(new Vector3(screenPoint.x, screenPoint.y, Camera.main.nearClipPlane));
            worldPoint.z = 0;
            _position.SetValue(worldPoint);
        }

        private void LateUpdate()
        {
            transform.position = _position.GetValue();
        }
    }
}