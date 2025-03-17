using Entitas;
using UnityEngine;

namespace Script.System
{
    public class LifeTimeSystem: IExecuteSystem
    {
        private IGroup<GameEntity> mGroup;
        
        public LifeTimeSystem(Contexts contexts)
        {
            mGroup = contexts.game.GetGroup(GameMatcher.ScriptComponentsLife);
        }
        
        public void Execute()
        {
            var dt = Time.deltaTime;
            foreach (var entity in mGroup)
            {
                var newTime = entity.scriptComponentsLife.Time - dt;
                entity.scriptComponentsLife.Time -= dt;
                if (newTime <= 0)
                {
                    entity.isScriptComponentsDestoryFlag = true;
                }
                else
                {
                    entity.ReplaceScriptComponentsLife(newTime);
                }
            }

        }
    }
}