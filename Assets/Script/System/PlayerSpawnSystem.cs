using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Script.System
{
    public class PlayerSpawnSystem : IInitializeSystem
    {
        
        public void Initialize()
        {
            EntityUtil.CreatePlayerEntity();
        }
    }
}