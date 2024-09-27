using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : Spawner
{
    [SerializeField] protected ObjectToSpawnPrefab<CatBehaviour> objToSpawn;
    [SerializeField] Transform destination;
    public override void Spawn()
    {
        for (int i = 0; i < spawnPos.Count; i++)
        {
            var pos = spawnPos[i].RandomPos();
            var go = Instantiate(objToSpawn.Objects[Random.Range(0, objToSpawn.Objects.Count)]);
            go.Follow(destination);
            go.transform.position = pos;
        }
    }
}
