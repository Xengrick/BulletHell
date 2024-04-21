using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int vidas = 3;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update se llama una vez por frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1") ||
            collision.gameObject.CompareTag("Enemy2") ||
            collision.gameObject.CompareTag("Enemy3"))
        {
            PerderVida();
        }
        Destroy(collision.gameObject);
    }

    private void PerderVida()
    {
        vidas--;

        if (vidas <= 0)
        {
            MuerteDelJugador();
        }
    }

    private void MuerteDelJugador()
    {
        Destroy(gameObject);
        Debug.Log("El jugador ha muerto.");
    }
}

