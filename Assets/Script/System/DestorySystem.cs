using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Script.System
{
    public class DestorySystem : ICleanupSystem
    {
        private IGroup<GameEntity> mGroup;

        public DestorySystem(Contexts contexts)
        {
            mGroup = contexts.game.GetGroup(GameMatcher.ScriptComponentsDestoryFlag);
        }
        public void Cleanup()
        {
            foreach (var entity in mGroup.GetEntities())
            {
                entity.Destroy();
            }
        }
    }
}