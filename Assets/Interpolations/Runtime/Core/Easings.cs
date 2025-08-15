using UnityEngine;

namespace Interpolations.Runtime.Core
{
    public static class Easings
    {
        public static float Linear(float t)
        {
            return t;
        }

        public static float EaseInQuad(float t)
        {
            return t * t;
        }

        public static float EaseOutQuad(float t)
        {
            return t * (2 - t);
        }

        public static float EaseInOutQuad(float t)
        {
            if (t < 0.5f)
                return 2 * t * t;
            return -1 + (4 - 2 * t) * t;
        }

        public static float EaseInCubic(float t)
        {
            return t * t * t;
        }

        public static float EaseOutCubic(float t)
        {
            return --t * t * t + 1;
        }

        public static float EaseInOutCubic(float t)
        {
            if (t < 0.5f)
                return 4 * t * t * t;
            return (t - 1) * (2 * (t - 1)) * (2 * (t - 1)) + 1;
        }

        public static float EaseInQuart(float t)
        {
            return t * t * t * t;
        }

        public static float EaseOutQuart(float t)
        {
            return 1 - --t * t * t * t;
        }

        public static float EaseInOutQuart(float t)
        {
            if (t < 0.5f)
                return 8 * t * t * t * t;
            return 1 - 8 * --t * t * t * t;
        }

        public static float EaseInElastic(float t)
        {
            if (t is 0 or 1) return t;
            return Mathf.Pow(2, 10 * (t - 1)) * Mathf.Sin((t - 1.1f) * (2 * Mathf.PI) / 0.4f);
        }

        public static float EaseOutElastic(float t)
        {
            if (t is 0 or 1) return t;
            return 1 - Mathf.Pow(2, -10 * t) * Mathf.Sin((t - 0.1f) * (2 * Mathf.PI) / 0.4f);
        }

        public static float EaseInOutElastic(float t)
        {
            return t switch
            {
                0 or 1 => t,
                < 0.5f => 0.5f * Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * (2 * Mathf.PI) / 0.4f),
                _ => 1 - 0.5f * Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * (2 * Mathf.PI) / 0.4f)
            };
        }
    }
}