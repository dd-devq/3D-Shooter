using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hiep
{
    public class PoolDefine : MonoBehaviour
    {
        public static PoolDefine Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void InitPool(Action callback = null)
        {
            Transform transBulletAuto = Resources.Load<Transform>("BulletAuto") as Transform;
            CreatePool(NamePool.PoolBulletAuto, 50, transBulletAuto);

            Transform transImpactEnemy = Resources.Load<Transform>("ImpactEnemy") as Transform;
            CreatePool(NamePool.PoolImpactEnemy, 50, transImpactEnemy);

            if (callback != null)
            {
                callback();
            }
        }

        private void CreatePool(NamePool namePool, int maxObject, Transform prefabObjects)
        {
            Pool pool = new Pool();
            pool.namePool = namePool.ToString();
            pool.maxObject = maxObject;
            pool.prefab = prefabObjects;
            PoolManager.Instance.AddNewPool(pool);

        }
    }


    public enum NamePool
    {
        PoolBulletAuto = 0,
        PoolImpactEnemy = 1,

    }
}


