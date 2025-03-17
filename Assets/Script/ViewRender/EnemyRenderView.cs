using UnityEngine;
using Entitas.Unity;
using Script.ViewRender;

namespace Script
{
    public class EnemyRenderView: RenderView
    {
        protected override void OnDestroyFlagHander()
        {
            //Destroy(gameObject);
        }
    }
}