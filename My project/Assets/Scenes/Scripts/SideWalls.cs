using UnityEngine;
using System.Collections;
public class SideWalls : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // if(hitInfo.gameObject.CompareTag("Ball"))
        if (hitInfo.tag == "Ball")
        {
            print("Entrou!");
            string wallName = transform.name;
            hitInfo.gameObject.GetComponent<VidaJogador>().tiraVida();
            hitInfo.gameObject.SendMessage("RestartGame", 1.0f, SendMessageOptions.RequireReceiver);
        }

    }
}
