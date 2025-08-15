namespace Interpolations.Runtime.Core
{
    public interface IInterpolation<T>
    {
        T Evaluate(T from, T to, float t);
    }

    public delegate float EasingFunction(float t);
}