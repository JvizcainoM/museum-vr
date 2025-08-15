using UnityEngine;

namespace Runtime.Utils
{
    public static class Math
    {
        public static Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
        {
            var u = 1 - t;
            var tt = t * t;
            var uu = u * u;

            return uu * p0 + 2 * u * t * p1 + tt * p2;
        }
    }
}