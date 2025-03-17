using UnityEngine;
using Entitas.Unity;
using Script.ViewRender;

namespace Script
{
    public class PlayerRenderView: RenderView
    {
        public Transform Shoot;

        protected override void OnDestroyFlagHander()
        {
            Destroy(gameObject);
        }
    }
}