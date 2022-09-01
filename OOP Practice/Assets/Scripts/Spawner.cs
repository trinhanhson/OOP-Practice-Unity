using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemys;
    [SerializeField] float spawnSpeed;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnSpeed, spawnSpeed);
    }

    void Spawn()
    {
        Instantiate(enemys[Random.Range(0, enemys.Count)], new Vector3(Random.Range(-45, 45), 10, Random.Range(-45, 45)), Quaternion.identity);
    }
}
