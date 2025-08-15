namespace Interpolations.Runtime.Core
{
    public abstract class Interpolated<T>
    {
        private T Start { get; set; }
        private T End { get; set; }
        private float StartTime { get; set; }
        private float Speed { get; set; } = 1f;

        private EasingFunction _easing;
        private readonly IInterpolation<T> _interpolation;

        protected Interpolated(T initialValue, IInterpolation<T> interpolation)
        {
            Start = End = initialValue;
            _interpolation = interpolation;
        }

        public Interpolated<T> SetEasing(EasingFunction easing)
        {
            _easing = easing;
            return this;
        }

        public Interpolated<T> SetDuration(float duration)
        {
            Speed = 1.0f / duration;
            return this;
        }

        public void SetValue(T newValue)
        {
            Start = GetValue();
            End = newValue;
            StartTime = GetCurrentTime();
        }

        public T GetValue()
        {
            var elapsed = GetElapsedSeconds();
            var t = elapsed * Speed;
            return t >= 1.0f ? End : _interpolation.Evaluate(Start, End, _easing?.Invoke(t) ?? t);
        }

        private float GetElapsedSeconds()
        {
            return GetCurrentTime() - StartTime;
        }

        private static float GetCurrentTime()
        {
            return UnityEngine.Time.time;
        }
    }
}