using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Script.Components
{
    [Game,Input]//上下文 目前只有这两
    public class IdComponent : IComponent
    {
        //确保唯一标签 会生成 IScriptComponentsIdEntity
        [PrimaryEntityIndex]
        public int EntityId;
    }
}