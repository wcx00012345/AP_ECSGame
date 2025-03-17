using UnityEngine;
using Entitas.Unity;
using Script.ViewRender;

namespace Script
{
    public class BulletRenderView: RenderView
    {
        protected override void OnDestroyFlagHander()
        {
            PoolManager.Instance.mBoomPrefabPool.Recycle(this);
        }
    }
}