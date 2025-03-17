using Entitas;
using Script.Components;
using UnityEngine;

namespace Script.System
{
    public class InputSystem: IExecuteSystem,ICleanupSystem
    {
        public readonly Contexts mContext;
        
        public readonly IGroup<GameEntity> mGroup;

        public InputSystem(Contexts context)
        {
         
            mContext = context;
            //mGroup = mContext.game.GetGroup()
        }
        
        public void Execute()
        {
            var inputEnttiy = mContext.input.CreateEntity();
            inputEnttiy.AddScriptComponentsInput(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
                Input.mousePosition, Input.GetMouseButton(0));
        }

        public void Cleanup()
        {
            mContext.input.DestroyAllEntities();
        }
    }
}