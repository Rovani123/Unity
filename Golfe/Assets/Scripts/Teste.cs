using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teste : MonoBehaviour {

    public float x, y;
    float velocidade;
    LineRenderer lr;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        if (lr == null)
            Debug.Log("Adicionar LineRenderer");
	}
	
    // Update is called once per frame
	void Update () {
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y));
        if (Input.GetButtonDown("Jump") && lr.enabled)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(
                2 * x, 0, 2 * y), ForceMode.Impulse);
            lr.enabled = false;
            if (GameManager.gm){
                GameManager.gm.tacada();
            }

        }
        velocidade = rb.velocity.magnitude;
        //Debug.Log("velocidade: " + velocidade);
        if (velocidade < 0.05f)
        {
            //Stop Moving/Translating
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            lr.enabled = true;
        }
        else 
            lr.enabled = false;
    }
}
