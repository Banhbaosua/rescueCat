using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : Spawner
{
    [SerializeField] protected ObjectToSpawnPrefab<CatBehaviour> objToSpawn;
    public override void Spawn()
    {
        for (int i = 0; i < spawnPos.Count; i++)
        {
            var pos = spawnPos[i].RandomPos();
            var go = Instantiate(objToSpawn.Objects[Random.Range(0, objToSpawn.Objects.Count - 1)]);
            go.transform.position = pos;
        }
    }
}
