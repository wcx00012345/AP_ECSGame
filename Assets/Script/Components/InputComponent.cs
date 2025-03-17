using Entitas;
using UnityEngine;

namespace Script.Components
{
    [Input]
    public class InputComponent: IComponent
    {
        public Vector2 InputVal;

        public Vector2 MousePos;

        public bool MouseInput;
    }
}