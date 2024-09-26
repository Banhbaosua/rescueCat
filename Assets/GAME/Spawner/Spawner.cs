using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected List<SpawnPosData> spawnPos;
    public abstract void Spawn();
}
