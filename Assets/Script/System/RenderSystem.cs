using Entitas;
using UnityEngine;

namespace Script.System
{
    public class RenderSystem: IExecuteSystem
    {
        public Contexts mContext;
        public IGroup<GameEntity> mGroup;

        public RenderSystem(Contexts contexts)
        {
            mContext = contexts;
            mGroup = contexts.game.GetGroup(GameMatcher.ScriptComponentsRender);
        }
        
        public void Execute()
        {
            foreach (var entity in mGroup)
            {
                var render = entity.scriptComponentsRender.Render;
                var posCom = entity.scriptComponentsPos.Pos;
                var rotCom = entity.scriptComponentsRotation.Rot;
                render.transform.position = posCom;
                render.transform.rotation = Quaternion.Euler(0,0,rotCom);
            }
        }
    }
}