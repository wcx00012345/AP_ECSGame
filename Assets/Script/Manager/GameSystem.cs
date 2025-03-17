using Entitas;
using Script.System;


public sealed class GameSystem : Feature
{
    public GameSystem(Contexts context)
    {
        //玩家
        Add(new PlayerSpawnSystem());
        //敌人
        Add(new EnemySpawnSystem(context));
        //输出
        Add(new InputSystem(context));
        //输入处理
        Add(new InputProgressSystem(context));
        //目标跟随
        Add(new FollowTargetSystem(context));
        
        //移动
        Add(new MovementSystem(context));
        
        //生成创建
        Add(new SpawnObjSystem(context));
        
        //具体的操作预制体渲染
        Add(new RenderSystem(context));
        
        //生命周期
        Add(new LifeTimeSystem(context));
        //销毁
        Add(new DestorySystem(context));
        //处理销毁后
        Add(new GameEventSystems(context));
    }
}