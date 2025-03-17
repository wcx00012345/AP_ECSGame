using System;
using Script.Pool;
using UnityEngine;

namespace Script
{
    public class PoolManager: MonoBehaviour
    {
        public static PoolManager Instance;

        public RenderPrefabPool mBoomPrefabPool;

        public void Awake()
        {
            if (Instance != null)
            {
                GameObject.Destroy(Instance.gameObject);
            }

            Instance = this;
            
            mBoomPrefabPool.Preload(5);
        }
    }
}