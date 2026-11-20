using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefab;
    public float spawnRate;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    public void FastSpawn() {
        spawnRate = 1f;
        OnDisable();
        OnEnable();
    }
        public void SlowSpawn() {
        spawnRate = 2f;
        OnDisable();
        OnEnable();
    }


    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn(){
        GameObject taggar = Instantiate(prefab[Random.Range(0, prefab.Length)], transform.position, Quaternion.identity);
        taggar.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
