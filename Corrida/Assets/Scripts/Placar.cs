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
    void Start()
    {
        placar = 0;
        recorde = PlayerPrefs.GetInt("recorde", 0);

        mostradorRecorde.text = "Recorde: " + recorde;

        InvokeRepeating("pontua", 0.3f, 0.3f);
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
}