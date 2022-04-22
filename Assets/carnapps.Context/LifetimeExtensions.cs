namespace carnapps.Context
{
    using System;
    using UniRx;
    using carnapps.Context.Abstract;

    static class LifetimeExtensions
    {
        public static IDisposable AddTo(this IDisposable disposable, ILifetime lifetime)
        {
            return disposable.AddTo(lifetime.LifetimeContext);
        }
    }
}