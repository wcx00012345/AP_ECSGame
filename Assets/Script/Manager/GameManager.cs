using System;
using System.Collections.Generic;
using Script;
using Script.Other;
using Script.Pool;
using UnityEngine;
using Unity;


/// <summary>
/// 游戏管理类 驱动所有系统
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public static Contexts Contexts => Instance.mContexts;
    
    private GameSystem mGameSystem;
    private Contexts mContexts;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
        
        mContexts = Contexts.sharedInstance;
        mContexts.SubscribeId();

        var phyEntity = mContexts.physics.CreateEntity();
        phyEntity.AddScriptComponentsPhysics(new List<CollisionInfo>());
        
        mGameSystem = new GameSystem(mContexts);
    }

    private void Start()
    {
        //用法要求
        mGameSystem.Initialize();
        
    }

    private void Update()
    {
        mGameSystem.Execute();
        mGameSystem.Cleanup();
    }
    
    
    private void FixedUpdate()
    {

    }
    

    private void OnDestroy()
    {
        mGameSystem.TearDown();
    }
}