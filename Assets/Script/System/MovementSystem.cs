using Entitas;
using Script.ViewRender;
using UnityEngine;

namespace Script.System
{
    public class MovementSystem: IExecuteSystem
    {
        private readonly IGroup<GameEntity> mGroup;
        
        public MovementSystem(Contexts context)
        {
            mGroup = context.game.GetGroup(GameMatcher.AllOf(GameMatcher.ScriptComponentsPos,GameMatcher.ScriptComponentsSpeed,GameMatcher.ScriptComponentsPhysicsTag,
                GameMatcher.ScriptComponentsRender));
        }
        
        public void Execute()
        {
            foreach (var entity in mGroup.GetEntities())
            {
                var speedComp = entity.scriptComponentsSpeed.Speed;
                //施加一个速度
                var rigidbody = ((IPhysicsView)entity.scriptComponentsRender.Render).Rigidbody2D;
                rigidbody.velocity = speedComp;
                //位置赋值给 pos组件
                entity.ReplaceScriptComponentsPos(entity.scriptComponentsRender.Render.transform.position);
            }
        }
    }
}