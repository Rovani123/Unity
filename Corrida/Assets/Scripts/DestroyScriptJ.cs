using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScriptJ : MonoBehaviour
{
    public Canvas GameOver;
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

        if(outro.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            GameOver.gameObject.SetActive(true);
            return;
        }
        else
        {
            // if (outro.gameObject.transform.parent)
            //     Destroy(outro.gameObject.transform.parent.gameObject);
            // else
            if(outro.gameObject.tag == "Player"){
                Destroy(outro.gameObject);
            }
        }
    }
}



