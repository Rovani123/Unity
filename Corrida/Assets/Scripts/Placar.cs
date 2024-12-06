using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Platformer;

public class Placar : MonoBehaviour
{
    public TMP_Text mostrador;
    public TMP_Text mostradorRecorde;
    private int placar;
    private int recorde;

    private PlayerController script;
    void Start()
    {
        script = GameObject.Find("Jogador").GetComponent<PlayerController>();
        placar = 0;
        recorde = PlayerPrefs.GetInt("recorde", 0);

        mostradorRecorde.text = "Recorde: " + recorde;

        InvokeRepeating("pontua", 0.3f, 0.3f);
    }

    void Update()
    {
        aumentarVel();
    }

    void pontua()
    {
        placar += 1;
        if(placar > recorde)
        {
            recorde = placar;
            PlayerPrefs.SetInt("recorde", recorde);
        }
        mostrador.text = placar+"";
        mostradorRecorde.text = "Recorde: " + recorde;
    }

    public void pontuar(int i)
    {
        placar += i;
    }

    public void aumentarVel()
    {
        if(placar > 200 && placar <300)
        {
            script.movingSpeed = 6;
        }else if(placar > 300)
        {
            script.movingSpeed = 7;
        }
    }
}