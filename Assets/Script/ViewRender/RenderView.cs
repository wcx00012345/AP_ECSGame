using System;
using Entitas;
using UnityEngine;
using Entitas.Unity;
using Script.Pool;
using Script.ViewRender;
namespace Script
{
    public class RenderView: MonoBehaviour,IPhysicsView,IScriptComponentsDestoryFlagListener
    {
        [SerializeField]private Rigidbody2D mRigidbody2D;
        public Rigidbody2D Rigidbody2D => mRigidbody2D;
        
        protected GameEntity mSelfEntity => gameObject.GetEntityLink().entity as GameEntity;
        
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            var selfEntity = mSelfEntity;
            var otherEntity = other.gameObject.GetEntityLink().entity as GameEntity;
            
            GameManager.Contexts.physics.scriptComponentsPhysics.CollisionInfos.Add(
                new CollisionInfo()
                {
                    SourceId = selfEntity.scriptComponentsId.EntityId,
                    OtherId = otherEntity.scriptComponentsId.EntityId
                });
        }
    }
}