using Entitas;
using UnityEngine;
using Entitas.Unity;
using Script.ViewRender;
using NotImplementedException = System.NotImplementedException;

namespace Script
{
    public class RenderView: MonoBehaviour,IRenderView,IScriptComponentsDestoryFlagListener
    {
        public void Link(Contexts contexts, IEntity entity)
        {
            var entityItem = (GameEntity)entity;
            
            gameObject.Link(entity);
           
            entityItem.AddScriptComponentsDestoryFlagListener(this);
        }

        public void OnScriptComponentsDestoryFlag(GameEntity entity)
        {
            gameObject.Unlink();
            OnDestroyFlagHander();
        }

        protected virtual void OnDestroyFlagHander()
        {
            
        }
    }
}