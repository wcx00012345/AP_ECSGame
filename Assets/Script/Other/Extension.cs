using System;
using Entitas;
using Script.Components;
using UnityEngine;

namespace Script.Other
{
    public static class Extension
    {
        public static Vector2 Angle2Vector2D(this float angle)
        {
            var a = (angle + 90) * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
        }
        
        
        public static float Vector2D2Angle(this Vector2 dir)
        {
            return Vector2.SignedAngle(Vector2.up, dir);
        }
        
        public static void SubscribeId (this Contexts contexts)
        {
            foreach (var context in contexts.allContexts)
            {
                if (Array.FindIndex(context.contextInfo.componentTypes, v => v == typeof(IdComponent)) >= 0)
                {
                    context.OnEntityCreated += AddId;
                }
            }
        }
        
        public static void AddId (IContext context, IEntity entity)
        {
            (entity as IScriptComponentsIdEntity).ReplaceScriptComponentsId(entity.creationIndex);
        }
        
        
    }
}