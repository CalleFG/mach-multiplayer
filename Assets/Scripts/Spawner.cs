using System;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

namespace Mach
{
    public class Spawner : AttributesSync
    {
        [SerializeField] private GameObject[] _spawnableObjects;

        private List<(GameObject, Guid)> SpawnedObjects = new();

        public GameObject Spawn(int index, Vector3 position, Quaternion rotation)
        {
            GameObject obj = Instantiate(_spawnableObjects[index], position, rotation);
            Guid id = Guid.NewGuid();
            obj.GetComponent<CommunicationBridgeUID>().OverrideUID(id);
            SpawnedObjects.Add((obj, id));
            InvokeRemoteMethod("SpawnInternal", ushort.MaxValue, id, index, position.x, position.y, rotation.eulerAngles.z);
        
            return obj;
        }
    
        public void Despawn(GameObject obj)
        {
            for (int i = 0; i < SpawnedObjects.Count; ++i)
            {
                if (SpawnedObjects[i].Item1 == obj)
                {
                    Destroy(SpawnedObjects[i].Item1);
                    InvokeRemoteMethod("DespawnInternal", ushort.MaxValue, SpawnedObjects[i].Item2);
                    SpawnedObjects.Remove(SpawnedObjects[i]);
                    break;
                }
            }
        }

        // Since our game is topdown 2D we can cut out unnecessary bloat and just send the X,Y position along with Z rotation.
        [SynchronizableMethod]
        private void SpawnInternal(Guid id, int index, float posX, float posY, float rotZ)
        {
            GameObject obj = Instantiate(_spawnableObjects[index], new Vector3(posX, posY, 0.0f), Quaternion.Euler(0.0f, 0.0f, rotZ));
            obj.GetComponent<CommunicationBridgeUID>().OverrideUID(id);
            SpawnedObjects.Add((obj, id));
        }

        [SynchronizableMethod]
        private void DespawnInternal(Guid id)
        {
            for (int i = 0; i < SpawnedObjects.Count; ++i)
            {
                if (SpawnedObjects[i].Item2 == id)
                {
                    Destroy(SpawnedObjects[i].Item1);
                    SpawnedObjects.Remove(SpawnedObjects[i]);
                    break;
                }
            }
        }
    }
}

