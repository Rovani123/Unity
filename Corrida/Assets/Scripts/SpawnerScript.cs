using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] vetor;
    public float sapwnMin;
    public float sapwnMax;
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(vetor[Random.Range(0, vetor.Length)], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(sapwnMin, sapwnMax));
    }
}