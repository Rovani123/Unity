using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregarNivel : MonoBehaviour
{
	public string carregarNivel;
	
	public void CarregaNivel() {
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(carregarNivel);
	}
}
