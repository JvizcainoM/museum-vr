namespace Interpolations.Runtime.Core
{
    public class Vector2Interpolated : Interpolated<UnityEngine.Vector2>
    {
        public Vector2Interpolated(UnityEngine.Vector2 initialValue) : base(initialValue, Interpolators.Vector2)
        {
        }
    }
}