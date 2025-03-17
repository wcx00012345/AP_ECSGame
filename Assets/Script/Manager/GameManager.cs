using System;
using Script;
using Script.Other;
using UnityEngine;
using Unity;


/// <summary>
/// 游戏管理类 驱动所有系统
/// </summary>
public class GameManager : MonoBehaviour
{
    private GameSystem mGameSystem;
    private void Awake()
    {
        mGameSystem = new GameSystem(Contexts.sharedInstance);
    }

    private void Start()
    {
        //用法要求
        var cont = Contexts.sharedInstance;
        cont.SubscribeId();
        
        mGameSystem.Initialize();
        
    }

    private void Update()
    {
        mGameSystem.Execute();
        mGameSystem.Cleanup();
    }

    private void OnDestroy()
    {
        mGameSystem.TearDown();
    }
}