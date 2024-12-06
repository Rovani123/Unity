using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScriptJ : MonoBehaviour
{
    public GameObject GameOver;
    void Start()
    {
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D outro)
    {

        if(outro.gameObject.tag == "Obstaculo")
        {
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
            return;
        }
    }

}



