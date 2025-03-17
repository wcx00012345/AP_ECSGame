using Entitas;
using UnityEngine;

namespace Script.System
{
    public class MovementSystem: IExecuteSystem
    {
        private readonly IGroup<GameEntity> mGroup;
        
        public MovementSystem(Contexts context)
        {
            mGroup = context.game.GetGroup(GameMatcher.AllOf(GameMatcher.ScriptComponentsPos,GameMatcher.ScriptComponentsSpeed));
        }
        
        public void Execute()
        {
            var dt = Time.deltaTime;
            foreach (var entity in mGroup.GetEntities())
            {
                var posComp = entity.scriptComponentsPos.Pos;
                var speedComp = entity.scriptComponentsSpeed.Speed;
                entity.ReplaceScriptComponentsPos(new Vector2(posComp.x + speedComp.x * dt
                    ,posComp.y+ speedComp.y * dt));
            }
        }
    }
}