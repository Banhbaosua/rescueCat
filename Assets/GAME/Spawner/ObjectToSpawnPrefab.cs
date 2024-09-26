using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectToSpawnPrefab<T> : ScriptableObject where T : MonoBehaviour
{
    [SerializeField] List<T> objects;
    public List<T> Objects => objects;
}
