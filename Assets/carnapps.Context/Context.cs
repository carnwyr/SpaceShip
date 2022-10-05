using System;
using System.Collections.Generic;
using carnapps.Context.Abstract;
using Cysharp.Threading.Tasks;
using UniRx;

namespace carnapps.Context
{
    public class Context : Lifetime, IContext
    {
        private readonly IReactiveDictionary<Type, object> _context = new ReactiveDictionary<Type, object>();

        public void Publish<T>(T obj) where T : class
        {
            _context.Add(typeof(T), obj);
            if (obj is IDisposable disposableObject)
            {
                disposableObject.AddTo(this);
            }
        }

        public T Get<T>() where T : class
        {
            ((IDictionary<Type, object>) _context).TryGetValue(typeof(T), out var obj);
            return obj as T;
        }

        public async UniTask<T> GetFirstAsync<T>(ILifetime lifetime) where T : class
        {
            if (((IDictionary<Type, object>) _context).TryGetValue(typeof(T), out var obj))
            {
                return obj as T;
            }

            return await _context.ObserveAdd()
                .Where(x => x.Value is T)
                .First()
                .Select(x => x as T)
                .ToUniTask(cancellationToken: lifetime.AsCancellationToken());
        }
    }
}