using UnityEngine;
using UnityEngine.UI;
using Runtime.Utils;

namespace Runtime.Components.UI
{
    public class UIBezierLine : Graphic
    {
        public RectTransform pointA;
        public RectTransform pointB;
        public int segmentCount = 10;
        public float curveOffset = 5f;
        public float thickness = 4f;

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            if (pointA == null || pointB == null) return;

            Vector3 worldA = pointA.position;
            Vector3 worldB = pointB.position;
            var p0 = transform.InverseTransformPoint(worldA);
            var p2 = transform.InverseTransformPoint(worldB);

            var direction = (p2 - p0).normalized.y;
            var control = (p0 + p2) / 2 + Vector3.up * (curveOffset * direction);

            Vector3 prev = Math.CalculateQuadraticBezierPoint(0f, p0, control, p2);

            for (int i = 1; i <= segmentCount; i++)
            {
                float t = i / (float)segmentCount;
                Vector3 curr = Math.CalculateQuadraticBezierPoint(t, p0, control, p2);

                AddQuad(vh, prev, curr, thickness);
                prev = curr;
            }
        }

        private void AddQuad(VertexHelper vh, Vector3 start, Vector3 end, float width)
        {
            Vector3 direction = (end - start).normalized;
            Vector3 normal = Vector3.Cross(direction, Vector3.forward) * width * 0.5f;

            var v0 = start - normal;
            var v1 = start + normal;
            var v2 = end + normal;
            var v3 = end - normal;

            int index = vh.currentVertCount;

            vh.AddVert(v0, color, Vector2.zero);
            vh.AddVert(v1, color, Vector2.zero);
            vh.AddVert(v2, color, Vector2.zero);
            vh.AddVert(v3, color, Vector2.zero);

            vh.AddTriangle(index, index + 1, index + 2);
            vh.AddTriangle(index + 2, index + 3, index);
        }

        public void Refresh()
        {
            SetVerticesDirty();
        }
    }
}