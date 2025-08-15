using UnityEngine;

namespace Interpolations.Runtime.Core
{
    public class Vector2Interpolator : IInterpolation<Vector2>
    {
        public Vector2 Evaluate(Vector2 from, Vector2 to, float t)
        {
            return Vector2.LerpUnclamped(from, to, t);
        }
    }
}