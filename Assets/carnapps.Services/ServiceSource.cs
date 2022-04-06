using carnapps.Context.Abstract;
using carnapps.Services.Abstract;
using UnityEngine;

namespace carnapps.Services
{
    public abstract class ServiceSource : ScriptableObject, IServiceSource
    {
        public abstract IService CreateService(IContext context);
    }
}