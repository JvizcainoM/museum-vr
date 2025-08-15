using Runtime.Utils;
using UnityEngine;

namespace Runtime.Components
{
    [RequireComponent(typeof(LineRenderer))]
    public class BezierLine : MonoBehaviour
    {
        public Transform pointA;
        public Transform pointB;
        public int segmentCount = 10;
        public float curveOffset = 5f;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        private void LateUpdate()
        {
            DrawCurve();
        }

        private void DrawCurve()
        {
            _lineRenderer.positionCount = segmentCount + 1;
            var p0 = pointA.position;
            var p2 = pointB.position;

            var direction = (p2 - p0).normalized.y;
            var control = (p0 + p2) / 2 + Vector3.up * (curveOffset * direction);

            for (var i = 0; i <= segmentCount; i++)
            {
                var t = i / (float)segmentCount;
                var pos = Math.CalculateQuadraticBezierPoint(t, p0, control, p2);
                _lineRenderer.SetPosition(i, pos);
            }
        }
    }
}