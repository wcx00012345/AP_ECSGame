using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Script.Pool;
using UnityEngine;

namespace Script.Components
{
    //属于物理
    [physics]
    [Unique]//唯一
    public class PhysicsComponent: IComponent
    {
        public List<CollisionInfo> CollisionInfos;
    }
}