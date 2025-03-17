using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Script.System
{
    public class SpawnObjSystem: ReactiveSystem<GameEntity>
    {
        private readonly Contexts mContexts;

        public SpawnObjSystem(Contexts context):base(context.game)
        {
            mContexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ScriptComponentsCreateGameObjCompont);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var obj = SpawnObj(entity);
                entity.AddScriptComponentsRender(obj);
                entity.RemoveScriptComponentsCreateGameObjCompont();
            }
        }

        private RenderView SpawnObj(GameEntity entity)
        {
            var createCom = entity.scriptComponentsCreateGameObjCompont;
            var prefab = Resources.Load<GameObject>(createCom.path);
            RenderView view;
            if (createCom.path.Contains("Boom"))
            {
                view = PoolManager.Instance.mBoomPrefabPool.Spawn();
            }
            else
            {
                view = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity).GetComponent<RenderView>();
            }
            view.Link(mContexts,entity);
            return view;
        }
    }
}