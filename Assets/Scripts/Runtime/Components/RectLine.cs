using UnityEngine;

namespace Runtime.Components
{
    public class RectLine : MonoBehaviour
    {
        public Transform pointA;
        public Transform pointB;
        public int segmentCount = 2;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void LateUpdate()
        {
            DrawLine();
        }

        private void DrawLine()
        {
            _lineRenderer.positionCount = segmentCount + 1;
            var p0 = pointA.position;
            var p2 = pointB.position;

            for (var i = 0; i <= segmentCount; i++)
            {
                var t = i / (float)segmentCount;
                var pos = Vector3.Lerp(p0, p2, t);
                _lineRenderer.SetPosition(i, pos);
            }
        }
    }
}