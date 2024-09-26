using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpawnPosData")]
public class SpawnPosData : ScriptableObject
{
    [SerializeField] Vector3 center;
    [SerializeField] float radius;

    public float minX => center.x - radius;
    public float maxX => center.x + radius;
    public float minZ => center.z - radius;
    public float maxZ => center.z + radius;
    public Vector3 RandomPos()
    {
        var x = Random.Range(minX, maxX);
        var z = Random.Range(minZ, maxZ);
        return new Vector3(x,0,z);
    }
}
