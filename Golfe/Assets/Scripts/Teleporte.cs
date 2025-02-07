using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    // Posi��o Y de verifica��o
    public float checkYPosition = -10f;

    // Nova posi��o para onde o objeto ser� teleportado
    public Vector3 teleportPosition = new Vector3(0, 10, 0);

    // Update � chamado uma vez por frame
    void Update()
    {
        // Verifica se a posi��o Y do objeto est� abaixo da posi��o de verifica��o
        if (transform.position.y < checkYPosition)
        {
            // Teleporta o objeto para a nova posi��o
            transform.position = teleportPosition;
        }
    }
}
