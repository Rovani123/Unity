using UnityEngine;

public class AtrairObjetos : MonoBehaviour
{
    public string tagObjetos; // Tag dos objetos a serem atraídos
    public Transform objetoAlvo; // Objeto para o qual os outros objetos serão atraídos
    public float velocidadeAtracao = 5f; // Velocidade da atração

    void Update()
    {
        // Encontra todos os objetos com a tag especificada
        GameObject[] objetosParaAtrair = GameObject.FindGameObjectsWithTag(tagObjetos);

        // Atrai cada objeto para o objeto alvo
        foreach (GameObject objeto in objetosParaAtrair)
        {
            objeto.transform.position = Vector3.MoveTowards(objeto.transform.position, objetoAlvo.position, velocidadeAtracao * Time.deltaTime);
        }
    }
}
