using Entitas;

namespace Script.ViewRender
{
    public interface IRenderView
    { 
        void Link(Contexts contexts, IEntity entity);
    }
}