using System.Collections.Generic;
using carnapps.Services.Abstract;
using UnityEngine;

namespace carnapps.Services
{
    public class PositioningService : Service
    {
        private readonly float _noSpawnBorder;

        public PositioningService(float noSpawnBorder)
        {
            _noSpawnBorder = noSpawnBorder;
        }
        
        public Vector2 GetRandomPosition()
        {
            var posX = Random.Range(_noSpawnBorder - Screen.width / 2f, Screen.width / 2f - _noSpawnBorder);
            var posY = Random.Range(_noSpawnBorder - Screen.height / 2f,
                Screen.height / 2f - _noSpawnBorder);
            return new Vector2(posX, posY);
        }

        public Vector2 GetRandomPosition(IList<RectTransform> excludedAreas)
        {
            var posX = Random.Range(_noSpawnBorder - Screen.width / 2f, Screen.width / 2f - _noSpawnBorder);
            var posY = Random.Range(_noSpawnBorder - Screen.height / 2f,
                Screen.height / 2f - _noSpawnBorder);

            foreach (var area in excludedAreas)
            {
                var xOffset = 0;
                var yOffset = 0;
                
                if ((posX < area.rect.xMin || posX > area.rect.xMax) &&
                    (posY < area.rect.yMin || posY > area.rect.yMax))
                {
                    continue;
                }
                
                
            }
        }
    }
}