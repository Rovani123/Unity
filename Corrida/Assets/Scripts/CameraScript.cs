using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer;

public class CameraScript : MonoBehaviour
{
    private Player script;
    
    void Start()
    {
        script = GameObject.Find("Jogador").GetComponent<Player>();
    }

    
    void Update()
    {
        Vector3 direction = transform.right;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, script.getvelocidadeTotal() * Time.deltaTime);
    }
}
