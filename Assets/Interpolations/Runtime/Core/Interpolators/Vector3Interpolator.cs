using UnityEngine;

namespace Interpolations.Runtime.Core
{
    public class Vector3Interpolator : IInterpolation<Vector3>
    {
        public Vector3 Evaluate(Vector3 from, Vector3 to, float t)
        {
            return Vector3.LerpUnclamped(from, to, t);
        }
    }
}