using System;
using carnapps.Context.Abstract;
using UniRx;

namespace carnapps.Context
{
    public static class LifetimeExtensions
    {
        public static IDisposable AddTo(this IDisposable disposable, ILifetime lifetime)
        {
            return disposable.AddTo(lifetime.LifetimeContext);
        }
    }
}