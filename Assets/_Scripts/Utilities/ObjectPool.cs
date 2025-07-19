using System.Collections.Generic;
using _Scripts.Cards;
using UnityEngine;

namespace _Scripts.Utilities
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<PoolItem> poolItems;

        private Dictionary<CardType, Stack<GameObject>> _pools;
        private Dictionary<CardType, GameObject> _prefabLookup;
        private void Awake()
        {
            SetupPool();
        }
        private void SetupPool()
        {
            _pools = new();
            _prefabLookup = new();
            foreach (var item in poolItems)
            {
                var stack = new Stack<GameObject>();
                for (int i = 0; i < item.initialSize; i++)
                {
                    GameObject obj =  Instantiate(item.prefab, this.transform);
                    obj.SetActive(false);
                    stack.Push(obj);
                }
                _pools[item.key] = stack;
                _prefabLookup[item.key] = item.prefab;
            }
        }
        public GameObject GetPooledObject(CardType key)
        {
            if (!_pools.ContainsKey(key))
            {
                Debug.LogError($"No pool found for key {key}");
                return null;
            }
            if (_pools[key].Count == 0)
            {
                GameObject obj = Instantiate(_prefabLookup[key]);
                return obj;
            }
            GameObject pooledObject = _pools[key].Pop();
            pooledObject.SetActive(true);
            return pooledObject;
        }

        public void ReturnToPool(CardType key, GameObject pooledObject)
        {
            if (!_pools.ContainsKey(key))
            {
                Destroy(pooledObject);
                return;
            }
            pooledObject.SetActive(false);
            _pools[key].Push(pooledObject);
        }
    }
    [System.Serializable]
    public class PoolItem
    {
        public CardType key;                // unique key like "Unit", "Spell", etc.
        public GameObject prefab;
        public int initialSize = 10;
    }
}