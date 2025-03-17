using System.Collections.Generic;
using Entitas;
using Script.Components;
using Script.Other;
using Script.ViewRender;
using UnityEngine;

namespace Script.System
{
    public class InputProgressSystem : ReactiveSystem<InputEntity>
    {
        public readonly Contexts mContext;
        public readonly IGroup<GameEntity> mGroup;
        public readonly Camera mCamera;


        public InputProgressSystem(Contexts context) : base(context.input)
        {
            mContext = context;
            mGroup = context.game.GetGroup(GameMatcher.ScriptComponentsPlayer);
            mCamera = Camera.main;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ScriptComponentsInput);
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var playerEntity = mGroup.GetSingleEntity();
            foreach (InputEntity e in entities)
            {
                var pos = e.scriptComponentsInput.InputVal;
                playerEntity.ReplaceScriptComponentsSpeed(new Vector2(pos.x * 5, pos.y * 5));
                var worldPos = mCamera.ScreenToWorldPoint(new Vector3(e.scriptComponentsInput.MousePos.x,
                    e.scriptComponentsInput.MousePos.y, 10));
                var dir = new Vector2(worldPos.x, worldPos.y) - playerEntity.scriptComponentsPos.Pos;
                var angle = dir.Vector2D2Angle();
                playerEntity.ReplaceScriptComponentsRotation(angle);
                var click = e.scriptComponentsInput.MouseInput;
                if (click)
                {
                    var createPos = ((PlayerRenderView)playerEntity.scriptComponentsRender.Render).Shoot.position;
                    EntityUtil.CreateBulletEntity(mContext, createPos, angle.Angle2Vector2D() * 5,angle);
                }
            }
        }
    }
}