namespace carnapps.Boot
{
    using System.Collections.Generic;
    using carnapps.Context.Abstract;
    using carnapps.Services;
    using UnityEngine;
    
    public class GameBoot : MonoBehaviour
    {
        [SerializeField] private List<ServiceSource> _serviceSources = new List<ServiceSource>();

        private readonly IContext _context = new Context.Context();
    
        void Start()
        {
            foreach (var serviceSource in _serviceSources)
            {
                serviceSource.CreateService(_context);
            }
        }
    }
}
