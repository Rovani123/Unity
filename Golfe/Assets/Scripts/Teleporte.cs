using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    public float checkYPosition = -10f;
    Rigidbody rb;
    private Vector3 teleportPosition = new Vector3(0, 10, 0);
    private GameObject bola;

    void Start(){
        bola = GameObject.FindWithTag("Player");
        teleportPosition= bola.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < checkYPosition)
        {
            teleportar();
        }
    }

    public void setPosition(Vector3 position){
        teleportPosition = position;
    }

    public void teleportar()
    {
        transform.position = teleportPosition;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
