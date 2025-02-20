using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        rb2d.velocity = new Vector2(4, 4);

        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, 15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-50, 15));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y) + (coll.collider.attachedRigidbody.velocity.y);
            rb2d.velocity = vel;
        }
        else if (coll.collider.CompareTag("Ball"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = rb2d.velocity.y;
            rb2d.velocity = vel;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
