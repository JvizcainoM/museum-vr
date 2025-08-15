namespace Interpolations.Runtime.Core
{
    public class FloatInterpolated : Interpolated<float>
    {
        public FloatInterpolated(float initialValue) : base(initialValue, Interpolators.Float)
        {
        }
    }
}