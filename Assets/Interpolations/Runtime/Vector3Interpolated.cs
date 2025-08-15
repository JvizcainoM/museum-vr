namespace Interpolations.Runtime.Core
{
    public class Vector3Interpolated : Interpolated<UnityEngine.Vector3>
    {
        public Vector3Interpolated(UnityEngine.Vector3 initialValue) : base(initialValue, Interpolators.Vector3)
        {
        }
    }
}