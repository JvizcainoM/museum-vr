using UnityEngine;

namespace Runtime.Components
{
    public class NodeDragger : MonoBehaviour
    {
        private static NodeDragger CurrentlyDragging { get; set; }

        private bool _isDragging;
        private Vector3 _offset;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
            if (_mainCamera == null)
            {
                Debug.LogError("Main camera not found. Please ensure there is a camera tagged as 'MainCamera'.");
            }
        }

        private void OnMouseDown()
        {
            _isDragging = true;
            CurrentlyDragging = this;
        }

        private void OnMouseUp()
        {
            _isDragging = false;

            if (CurrentlyDragging == this)
                CurrentlyDragging = null;
        }

        private void Update()
        {
            if (!_isDragging) return;
        }
    }
}