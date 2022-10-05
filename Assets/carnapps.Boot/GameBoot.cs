using System.Collections.Generic;
using carnapps.Context.Abstract;
using carnapps.Services;
using UnityEngine;

namespace carnapps.Boot
{
    public class GameBoot : MonoBehaviour
    {
        [SerializeField] private List<ServiceSource> _serviceSources = new List<ServiceSource>();

        private readonly IContext _context = new Context.Context();

        private void Awake()
        {
            foreach (var serviceSource in _serviceSources)
            {
                serviceSource.CreateService(_context);
            }
        }
    }
}