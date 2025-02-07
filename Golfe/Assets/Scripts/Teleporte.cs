using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    // Posição Y de verificação
    public float checkYPosition = -10f;

    // Nova posição para onde o objeto será teleportado
    public Vector3 teleportPosition = new Vector3(0, 10, 0);

    // Update é chamado uma vez por frame
    void Update()
    {
        // Verifica se a posição Y do objeto está abaixo da posição de verificação
        if (transform.position.y < checkYPosition)
        {
            // Teleporta o objeto para a nova posição
            transform.position = teleportPosition;
        }
    }
}
