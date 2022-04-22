namespace carnapps.Context
{
    using System;
    using System.Collections.Generic;
    using carnapps.Context.Abstract;

    class Context : Lifetime, IContext
    {
        private readonly IDictionary<Type, object> _context = new Dictionary<Type, object>();

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
            _context.TryGetValue(typeof(T), out var obj);
            return obj as T;
        }
    }
}