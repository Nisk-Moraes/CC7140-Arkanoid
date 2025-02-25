using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1; // Pontuação do jogador

    public GUISkin layout;
    GameObject theBall;
    //GameObject transporte;
    public float LevelScore = 270;
    public int espera = 20;
    public string proximonivel = "lvl2";
    
    // Check if the name of the current Active Scene is your first Scene.
           

    public AudioClip sfxVenceuJogo;
    public AudioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        //transporte = GameObject.FindGameObjectWithTag("TRP");
        PlayerScore1 = Pontuacao.pontuacaoAtual;
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
    IEnumerator Espera(string proximonivel){
        yield return new WaitForSeconds(espera);
        if (proximonivel == null){ //falhou!
            WipeScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //recarregar o nivel
        }
        else{ //passou de nivel!
            if (theBall != null){
                Pontuacao.pontuacaoAtual = PlayerScore1;
            }
            
            else{
                Pontuacao.pontuacaoAtual = 0;
            }
                
            
            
            SceneManager.LoadScene(proximonivel);
        }
    }
   
    async Task OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 250 - 12, 40, 200, 100), "Score: " + PlayerScore1);
        if (PlayerScore1 >= LevelScore) // Verifica se o jogador ganhou
        {
            audioController.ToqueSFX(sfxVenceuJogo);
            
            if (theBall != null){
                GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
                theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            }
            else{ //quer dizer que eh o ultimo nivel
                GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "O JOGO IRA REINICIAR!");
                
                
            }
            
            StartCoroutine(Espera(proximonivel));
           
           
            

            
        }
        if (theBall.GetComponent<VidaJogador>().vidaAtual <= 0){
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "GAME OVER!");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            StartCoroutine(Espera(null));
            

            
        }
        
    }
    
}
