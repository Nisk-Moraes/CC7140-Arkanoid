using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do jogador

    public GUISkin layout;
    GameObject theBall;
    //GameObject transporte;
    public float LevelScore = 270;
    public string proximonivel = "lvl2";
    
    // Check if the name of the current Active Scene is your first Scene.
           

    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        //transporte = GameObject.FindGameObjectWithTag("TRP");
       
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Método para adicionar pontos
    public void AddScore(int points)
    {
        PlayerScore1 += points;
    }
    public void WipeScore(){
        PlayerScore1 = 0;
    }
    private IEnumerator Sleep(int temp){
        yield return new WaitForSeconds(temp);
    }
    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 250 - 12, 40, 200, 100), "Score: " + PlayerScore1);
        if (theBall.GetComponent<VidaJogador>().vidaAtual <= 0){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "GAME OVER!");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 >= LevelScore) // Verifica se o jogador ganhou
        {
            audioController.ToqueSFX(sfxVenceuJogo);
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            StartCoroutine(Sleep(20));
            WipeScore();
            SceneManager.LoadScene(proximonivel);
           
            

            
        }
    }
}
