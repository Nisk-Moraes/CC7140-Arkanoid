using UnityEngine;
using System.Collections;
public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
       if (hitInfo.tag == "Ball")
        {
            
            hitInfo.gameObject.GetComponent<VidaJogador>().tiraVida();
            if (hitInfo.gameObject.GetComponent<VidaJogador>().vidaAtual >0){
                hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
            }
            
        }

    }
}
