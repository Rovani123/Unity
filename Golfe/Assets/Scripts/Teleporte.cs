using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public float checkYPosition = -10f;

    private Vector3 teleportPosition = new Vector3(0, 10, 0);
    private GameObject bola;

    void Start(){
        bola = GameObject.FindWithTag("Player");
        teleportPosition= bola.transform.position;
    }

    void Update()
    {
        if (transform.position.y < checkYPosition)
        {
            transform.position = teleportPosition;
        }
    }

    public void setPosition(Vector3 position){
        teleportPosition = position;
    }
}
