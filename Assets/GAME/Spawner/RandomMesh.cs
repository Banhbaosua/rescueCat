using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMesh : MonoBehaviour
{
    [SerializeField] List<MeshFilter> meshFilters;
    [SerializeField] List<Mesh> meshes;
    private void Awake()
    {
        foreach(var filter in meshFilters)
        {
            var mesh = GetRandomMesh(meshes);
            filter.mesh = mesh;
        }
    }

    Mesh GetRandomMesh(List<Mesh> meshes)
    {
        return meshes[Random.Range(0, meshes.Count)];
    }
}
