using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buraco : MonoBehaviour
{
    public GameManager gamemanager;   
    private void OnTriggerEnter(Collider outro)
    {
        Time.timeScale = 0.0f;
		gamemanager.fimPartida();
    }
}
