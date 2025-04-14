using Entitas;
using Script.Components;
using Script.ViewRender;
using UnityEngine;

namespace Script.System
{
    public class PhysicsSystem: IExecuteSystem
    {
        private readonly PhysicsComponent mComp;

        private readonly Contexts mContext;
        
        public PhysicsSystem(Contexts context)
        {
            mContext = context;
            mComp = context.physics.scriptComponentsPhysics;
        }
        
        public void Execute()
        {
            foreach (var collision in mComp.CollisionInfos)
            {
                var sourceEntity = mContext.game.GetEntityWithScriptComponentsId(collision.SourceId);
                var otherEntity = mContext.game.GetEntityWithScriptComponentsId(collision.OtherId);
                if (sourceEntity.scriptComponentsRender.Render is BulletRenderView)
                {
                    if (otherEntity.scriptComponentsRender.Render is EnemyRenderView)
                    {
                        sourceEntity.isScriptComponentsDestoryFlag = true;
                        otherEntity.isScriptComponentsDestoryFlag = true;
                    }
                }
            }
            mComp.CollisionInfos.Clear();
        }
    }
}