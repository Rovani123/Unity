using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] vetor;
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(vetor[Random.Range(0, vetor.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn",8);
    }
}