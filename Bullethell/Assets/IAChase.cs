using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAChase : MonoBehaviour
{
    public string playerTag = "Player"; 
    public float speed;
    private Rigidbody2D rb2D;
    private GameObject player;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;


        player = GameObject.FindGameObjectWithTag(playerTag);

        if (player == null)
        {
            Debug.LogError("No se encontró un objeto con la etiqueta 'Player'.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 playerPosition = player.transform.position;
            Vector2 currentPosition = transform.position;

            Vector2 difference = playerPosition - currentPosition;

            difference.Normalize();

      
            if (Mathf.Abs(difference.x) > Mathf.Abs(difference.y))
            {
                rb2D.velocity = new Vector2(difference.x * speed, 0f);
            }
            else
            {
                rb2D.velocity = new Vector2(0f, difference.y * speed);
            }
        }
    }
}
