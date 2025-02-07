using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int fase;
    public GameObject tela;
    public GameObject telafinal;
    public TMP_Text textTacadas;
    public TMP_Text textPar;
    public int tacadas;
    public int par;
    private int pontuacao;
    private int recorde;
    public TMP_Text partxt;
    public TMP_Text tacadastxt;
    public TMP_Text recordetxt;
    public TMP_Text pontuacaotxt;

    
    void Start()
    {
        if (gm == null)
            gm = this.gameObject.GetComponent<GameManager>();
        recorde = PlayerPrefs.GetInt("recorde"+fase, 0);
        tacadas = 0;
        textTacadas.text = "Tacadas: 0";
        textPar.text = "Par: " + par;
    }

    public void tacada()
    {
        Debug.Log(tacadas);
        tacadas++;
        textTacadas.text = "Tacadas: "+ tacadas;
    }

    public void fimPartida()
    {
        telafinal.SetActive(true);
        tela.SetActive(false);
        partxt.text += par;
        tacadastxt.text += tacadas;
        pontuacao = tacadas - par;
        if(pontuacao < -2){
            pontuacaotxt.text += "Albatross";
        }else if(pontuacao == -2){
            pontuacaotxt.text += "Eagle";
        }else if(pontuacao == -1){
            pontuacaotxt.text += "Birdie";
        }else if(pontuacao == 0){
            pontuacaotxt.text += "Par";
        }else if(pontuacao == 1){
            pontuacaotxt.text += "Bogey";
        }else if(pontuacao == 2){
            pontuacaotxt.text += "Double Bogey ";
        }else if(pontuacao > 2){
            pontuacaotxt.text += "Triple Bogey";
        }
        if(recorde > pontuacao){
            recorde = pontuacao;
            PlayerPrefs.SetInt("recorde"+fase, recorde);
            recordetxt.text += recorde + " Novo Recorde!";
        }else{
            recordetxt.text += recorde;
        }
    }

}
