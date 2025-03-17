using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Pool
{
    [Serializable]
    public class PrefabPool<T> where T: Component
    {
        public Transform SpawnRoot;
        public Transform PoolRoot;
        
        public GameObject Prefab;
        private readonly Stack<T> mInpoolObjs = new Stack<T>();
        private readonly HashSet<T> mOutpoolObjs = new HashSet<T>();

        public void Preload(int count)
        {
            if (Prefab == null)
            {
                return;
            }

            if (mInpoolObjs.Count+mOutpoolObjs.Count>= count)
            {
                return;
            }

            var n = count - mInpoolObjs.Count - mOutpoolObjs.Count;
            for (int i = 0; i < n; i++)
            {
                var obj = Object.Instantiate(Prefab, Vector3.zero, Quaternion.identity);
                obj.SetActive(false);
                obj.transform.SetParent(PoolRoot);
                mInpoolObjs.Push(obj.GetComponent<T>());
            }
        }

        /// <summary>
        /// 生成对象
        /// </summary>
        /// <returns></returns>
        public T Spawn()
        {
            T obj;
            if (mInpoolObjs.Count>0)
            {
                obj = mInpoolObjs.Pop();
            }
            else
            {
                obj = Object.Instantiate(Prefab, Vector3.zero, Quaternion.identity).GetComponent<T>();
            }

            mOutpoolObjs.Add(obj);
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(SpawnRoot);
            return obj;
        }

        public bool Recycle(T obj)
        {
            if (!mOutpoolObjs.Contains(obj))
            {
                Object.Destroy(obj);
                return false;
            }

            mOutpoolObjs.Remove(obj);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(PoolRoot);
            mInpoolObjs.Push(obj);
            return true;
        }
        
        
    }
}