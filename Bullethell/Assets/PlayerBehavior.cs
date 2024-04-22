using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public int vidas = 3;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            PerderVida();
        }
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
        Debug.Log("El jugador ha muerto.");
        Destroy(gameObject);
    }
}

