namespace Interpolations.Runtime.Core
{
    public static class Interpolators
    {
        public static readonly FloatInterpolator Float = new();
        public static readonly Vector3Interpolator Vector3 = new();
        public static readonly Vector2Interpolator Vector2 = new();
    }
}