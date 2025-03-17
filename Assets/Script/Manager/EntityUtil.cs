
using Script.ViewRender;
using UnityEngine;

namespace Script
{
    public class EntityUtil
    {
        
        public static GameEntity CreatePlayerEntity()
        {
            var playerEntity = Contexts.sharedInstance.game.CreateEntity();
            playerEntity.isScriptComponentsPlayer = true;
            playerEntity.AddScriptComponentsPos(Vector2.zero);
            playerEntity.AddScriptComponentsSpeed(Vector2.zero);
            playerEntity.AddScriptComponentsRotation(0);
            playerEntity.AddScriptComponentsCreateGameObjCompont(GameDefine.PlayerPath);
            return playerEntity;
        }
        
        
        
        public static GameEntity CreateEnemyEntity(Contexts contests,Vector2 pos,Vector2 sd,float rot)
        {
            var entity = contests.game.CreateEntity();
            entity.AddScriptComponentsCreateGameObjCompont(GameDefine.EnemyPath);
            entity.AddScriptComponentsPos(pos);
            entity.AddScriptComponentsRotation(rot);
            entity.AddScriptComponentsSpeed(sd);
            return entity;
        }
        
        
        
        public static GameEntity CreateBulletEntity(Contexts contests,Vector2 pos,Vector2 sd,float rot)
        {
            var entity = contests.game.CreateEntity();
            entity.AddScriptComponentsCreateGameObjCompont(GameDefine.BoomPath);
            entity.AddScriptComponentsPos(pos);
            entity.AddScriptComponentsRotation(rot);
            entity.AddScriptComponentsSpeed(sd);
            entity.AddScriptComponentsLife(1);
            return entity;
        }
    }
}