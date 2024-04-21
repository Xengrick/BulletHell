using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
        rb2D.constraints = RigidbodyConstraints2D.FreezeRotation; 
    }

    void Update()
    {
        // Resetea la velocidad para evitar acumulación de fuerzas
        rb2D.velocity = Vector2.zero;

        if (Input.GetKey("a"))
        {
            rb2D.AddForce(Vector2.left * velocidad, ForceMode2D.Impulse);
        }

        if (Input.GetKey("d"))
        {
            rb2D.AddForce(Vector2.right * velocidad, ForceMode2D.Impulse);
        }

        if (Input.GetKey("w"))
        {
            rb2D.AddForce(Vector2.up * velocidad, ForceMode2D.Impulse);
        }

        if (Input.GetKey("s"))
        {
            rb2D.AddForce(Vector2.down * velocidad, ForceMode2D.Impulse);
        }

    }
}

