using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int blockPoints = 10;  // Pontos que este bloco vale ao ser destruído

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com a bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Adiciona pontos ao GameManager
            GameManager.PlayerScore1 += blockPoints;

            // Destrói o bloco
            Destroy(gameObject);
        }
    }
}
