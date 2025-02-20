using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do jogador

    public GUISkin layout;
    GameObject theBall;

    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Método para adicionar pontos
    public void AddScore(int points)
    {
        PlayerScore1 += points;
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 250 - 12, 40, 100, 100), "Score: " + PlayerScore1);

        if (PlayerScore1 >= 10) // Verifica se o jogador ganhou
        {
            audioController.ToqueSFX(sfxVenceuJogo);
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
}
