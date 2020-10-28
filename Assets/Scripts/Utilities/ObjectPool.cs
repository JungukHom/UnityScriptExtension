namespace developer0223.Utilities
{
    // C#
    using System;
    using System.Collections.Generic;

    // Unity
    using UnityEngine;

    // Utility
    using developer0223.Utilities.Exceptions;

    public class ObjectPool //<T> where T : MonoBehaviour
    {
        private readonly Vector3 defaultSpawnPosition = new Vector3(0, -500, 0);
        private readonly Quaternion defaultSpawnRotation = Quaternion.identity;
        private readonly GameObject reference = null;

        private readonly List<GameObject> pool = null;

        private ObjectPool()
        {
            pool = new List<GameObject>();
        }

        public ObjectPool(string prefabPath) : this()
        {
            reference = Resources.Load(prefabPath) as GameObject;
            if (!reference)
            {
                throw new NoSuchPrefabException("There is no Prefab at path : " + prefabPath);
            }
        }

        public ObjectPool(GameObject reference) : this()
        {
            this.reference = reference;
        }

        public void AddObjects(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                pool.Add(GameObject.Instantiate(reference, defaultSpawnPosition, defaultSpawnRotation));
            }
        }

        public void DeleteObjects(int amount)
        {
            DeleteUnActivedObjects(amount, out int remains);
            DeleteUnusedObjects(remains, out int last);
            DeleteAnyway(last);
        }

        public void Clear()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                GameObject.Destroy(pool[i].gameObject);
            }

            pool.Clear();
        }

        private void DeleteUnActivedObjects(int amount, out int remains)
        {
            int deleteCount = 0;
            int poolCount = pool.Count;
            List<int> toDeleteList = new List<int>();

            for (int i = 0; i < poolCount; i++)
            {
                if (deleteCount == amount) { break; }

                if (!pool[i].activeSelf)
                {
                    toDeleteList.Add(i);
                    deleteCount++;
                }
            }

            toDeleteList.Reverse();
            for(int i = 0; i < toDeleteList.Count; i++)
            {
                DeleteFromList(i);
            }

            remains = amount - deleteCount;
        }

        private void DeleteUnusedObjects(int amount, out int remains)
        {
            int deleteCount = 0;
            int poolCount = pool.Count;
            List<int> toDeleteList = new List<int>();

            for (int i = 0; i < poolCount; i++)
            {
                if (deleteCount == amount) { break; }

                if (pool[i].transform.position == defaultSpawnPosition)
                {
                    toDeleteList.Add(i);
                    deleteCount++;
                }
            }

            toDeleteList.Reverse();
            for (int i = 0; i < toDeleteList.Count; i++)
            {
                DeleteFromList(i);
            }

            remains = amount - deleteCount;
        }

        private void DeleteAnyway(int amount)
        {
            for (int i = pool.Count - 1; i >= 0; i--)
            {
                DeleteFromList(i);
            }
        }

        private void DeleteFromList(int index)
        {
            GameObject obj = pool[index];
            pool.RemoveAt(index);
            GameObject.Destroy(obj);
        }
    }
}