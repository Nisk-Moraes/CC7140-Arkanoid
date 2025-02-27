using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurableBlock : MonoBehaviour
{
    public int blockPoints = 10;  // Pontos que o bloco vale ao ser destruído
    private int hitCount = 0;     // Contador de hits

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com a bola
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitCount++; // Incrementa o contador de hits

            // Verifica se o bloco atingiu o número máximo de hits
            if (hitCount >= 2)
            {
                // Adiciona pontos ao GameManager
                GameManager.PlayerScore1 += blockPoints;

                // Destrói o bloco
                Destroy(gameObject);
            }
        }
    }
}
