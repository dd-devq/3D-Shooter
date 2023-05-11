using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Hiep
{

    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;
        public Dictionary<string, Pool> dicPools = new Dictionary<string, Pool>();
        [SerializeField]
        private List<Pool> pools = new List<Pool>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        // Start is called before the first frame update
        void Start()
        {
            foreach(Pool e in pools)
            {
                e.SetupPool();
                dicPools.Add(e.namePool, e);
            }
        }

        public void AddNewPool(Pool newPool)
        {
            if (!dicPools.ContainsKey(newPool.namePool))
            {
                newPool.SetupPool();
                dicPools.Add(newPool.namePool, newPool);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static Transform CreateNewPrefab(Transform prefab)
        {
            return Instantiate(prefab, Instance.transform);
        }
    }

    [Serializable]
    public class Pool
    {
        public string namePool;
        private List<Transform> gameobjects = new List<Transform>();
        public Transform prefab;
        public int maxObject;

        private int index = -1;
        public void SetupPool()
        {
            for(int i = 0; i < maxObject; i++)
            {
                Transform trans = PoolManager.CreateNewPrefab(prefab);                
                trans.gameObject.SetActive(false);
                gameobjects.Add(trans);
                trans.hideFlags = HideFlags.HideInHierarchy;
            }
        }

        public Transform GetObjectInstance()
        {
            index++;
            if (index >= maxObject)
            {
                index = 0;
            }

            Transform trans = gameobjects[index];
            trans.gameObject.SetActive(true);
            return trans;
        }

        public void DisableObjectPool(GameObject go)
        {
            go.SetActive(false);
        }
    }
}
