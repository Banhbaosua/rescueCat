using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Unity.AI.Navigation;
using UnityEngine.PlayerLoop;
using UnityEditor;
#if (UNITY_EDITOR) 
public class MapGenerator : MonoBehaviour
{
    [SerializeField] Transform minBound;
    [SerializeField] Transform maxBound;
    [SerializeField] List<GameObject> objToGenerate;
    [SerializeField] GameObject baseMap;
    private const float PERMAPOFFSET_X = 35f;
    private List<MapWrapper> generatedMap;
    private void Awake()
    {
        generatedMap = new List<MapWrapper>();
    }
    // Start is called before the first frame update
    public void GenerateMaps()
    {
        if (generatedMap.Count == 0)
        {
            for (int i = 0; i < 10; i++)
            {
                var map = Instantiate(baseMap);
                map.transform.position += Vector3.right * PERMAPOFFSET_X * (i + 1);
                var nmsurface = map.GetComponentInChildren<NavMeshSurface>();
                var new_minBound = minBound.position + Vector3.right*PERMAPOFFSET_X* (i+1);
                var new_maxBound = maxBound.position + Vector3.right*PERMAPOFFSET_X* (i+1);
                var data = new MapWrapper(map.transform,
                    nmsurface,
                    new_minBound,
                    new_maxBound);
                generatedMap.Add(data);
                SpawnProp(data, i + 3);
            }
            return;
        }

        for(int i = 0;i < 10;i++) 
        {
            var map = generatedMap[i];
            SpawnProp(map,i+3);
        }
    }

    public void SaveMaps()
    {
        if (generatedMap.Count == 0) return;
        for(int i= 0;i< 10;i++)
        {
            Save(i + 1);
        }
    }
    void Save(int level)
    {
        for (int i = 0; i < generatedMap.Count; i++)
        {
            string path = "Assets/GAME/Map/" + level.ToString() + ".prefab";
            path = AssetDatabase.GenerateUniqueAssetPath(path);

            var map = generatedMap[i].Map;
            PrefabUtility.SaveAsPrefabAssetAndConnect(map.gameObject, path, InteractionMode.UserAction);
        }
    }
    async void SpawnProp(MapWrapper map, int propsAmount)
    {
        for (int i = 0; i < propsAmount; i++)
        {
            var propPrefab = objToGenerate[Random.Range(0, objToGenerate.Count)];
            var prop = Instantiate(propPrefab, map.NmSurface.transform);
            var newPos = await FindAvailableSpawnPos(prop.GetComponent<Collider>(), map.MinBound, map.MaxBound);
            prop.transform.position = newPos;
        }
        map.NmSurface.BuildNavMesh();
    }

    async UniTask<Vector3> FindAvailableSpawnPos(Collider propCol,Vector3 minBound, Vector3 maxBound)
    {
        var radius = propCol.bounds.extents.magnitude;
        Debug.Log(radius);
        var pos_x = Random.Range(minBound.x, maxBound.x);
        var pos_z = Random.Range(minBound.z, maxBound.z);
        var hits = Physics.OverlapSphere(new Vector3(pos_x, 0, pos_z), radius);
        while (hits.Length > 0)
        {
            Debug.Log("collide");
            pos_x = Random.Range(minBound.x, maxBound.x);
            pos_z = Random.Range(minBound.z, maxBound.z);
            hits = Physics.OverlapSphere(new Vector3(pos_x, 0, pos_z), radius);
            await UniTask.WaitForFixedUpdate();
        }
        return new(pos_x,0,pos_z);
    }
}

public class MapWrapper
{
    public readonly Vector3 MinBound;
    public readonly Vector3 MaxBound;
    public readonly NavMeshSurface NmSurface;
    public readonly Transform Map;
    public MapWrapper(Transform map,NavMeshSurface nmSuface, Vector3 minBound, Vector3 maxBound)
    {
        Map = map;
        NmSurface = nmSuface;
        MinBound = minBound;
        MaxBound = maxBound;
    }
}
#endif
