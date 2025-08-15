using UnityEngine;

namespace Interpolations.Runtime.Core
{
    public class FloatInterpolator : IInterpolation<float>
    {
        public float Evaluate(float from, float to, float t)
        {
            return Mathf.LerpUnclamped(from, to, t);
        }
    }
}