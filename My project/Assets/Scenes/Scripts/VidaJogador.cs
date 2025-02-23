using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaJogador : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidaPlayer = 3;
    public int vidaAtual;
    GameObject theBall;
    //public bool alive = true;
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
        vidaAtual = vidaPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tiraVida(){
        vidaAtual -= 1;

        if(vidaAtual <= 0){
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
            Debug.Log("Game over");
        }
    }
}
