using System.Collections.Generic;
using Entitas;
using Script.Other;
using UnityEngine;

namespace Script.System
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private float dt = 0;

        private readonly Contexts mContexts;
        private readonly IGroup<GameEntity> mGroup;

        public EnemySpawnSystem(Contexts contexts)
        {
            mContexts = contexts;
            mGroup = contexts.game.GetGroup(GameMatcher.ScriptComponentsPlayer);
        }

        public void Execute()
        {
            dt += Time.deltaTime;
            if (dt >= 1)
            {
                var player = mGroup.GetSingleEntity();

                var x = UnityEngine.Random.Range(-9, 9);
                var y = UnityEngine.Random.Range(-5, 5);
                var createPos = new Vector2(x, y);
                var dir = player.scriptComponentsPos.Pos - createPos;
                var rot = dir.Vector2D2Angle();
                var entity =  EntityUtil.CreateEnemyEntity(mContexts, createPos,  rot.Angle2Vector2D() * 0,rot);
                entity.AddScriptComponentsTarget(player.scriptComponentsId.EntityId);
                dt = 0;
            }
        }
    }
}