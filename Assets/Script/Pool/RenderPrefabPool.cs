using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace Script.Pool
{
    [Serializable]
    public class RenderPrefabPool : PrefabPool<RenderView>
    {
        
    }

    [Serializable]
    public struct CollisionInfo
    {
        public int SourceId;
        [FormerlySerializedAs("TargetId")] public int OtherId;
    }
}