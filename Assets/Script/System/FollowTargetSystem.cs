using System.Collections.Generic;
using Entitas;
using Script.Other;
using UnityEngine;

namespace Script.System
{
    public class FollowTargetSystem : IExecuteSystem
    {
        private float dt = 0;

        private readonly Contexts mContexts;
        private readonly IGroup<GameEntity> mGroup;

        public FollowTargetSystem(Contexts contexts)
        {
            mContexts = contexts;
            mGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.ScriptComponentsPos,GameMatcher.ScriptComponentsSpeed,GameMatcher.ScriptComponentsTarget));
        }

        public void Execute()
        {
            foreach (var entity in mGroup.GetEntities())
            {
                var entityPos = entity.scriptComponentsPos.Pos;
                var targetEntity =
                    mContexts.game.GetEntityWithScriptComponentsId(entity.scriptComponentsTarget.TargetId);
                var dir = (targetEntity.scriptComponentsPos.Pos - entityPos).normalized;
                var angle = dir.Vector2D2Angle();
                entity.ReplaceScriptComponentsSpeed(new Vector2(dir.x * 1, dir.y * 1));
                entity.ReplaceScriptComponentsRotation(angle);
            }
        }   
    }
}