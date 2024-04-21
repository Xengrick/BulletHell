using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAChase : MonoBehaviour
{
    public GameObject player; // Referencia al objeto del jugador
    public float speed; // Velocidad de movimiento
    private float distance; // Distancia entre IA y jugador

    // Start es llamado antes del primer frame
    void Start()
    {
        // Inicializaci�n, si es necesario
    }

    // Update es llamado una vez por frame  
    void Update()
    {
        // Verifica si el objeto del jugador existe antes de ejecutar el c�digo
        if (player != null)
        {
            // Calcula la distancia entre el objeto IA y el jugador
            distance = Vector2.Distance(transform.position, player.transform.position);

            // Calcula la direcci�n hacia el jugador
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize(); // Normaliza para obtener solo la direcci�n
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // �ngulo de direcci�n

            // Solo mueve la IA si la distancia es menor que un valor espec�fico (4 en este caso)
            if (distance < 4)
            {
                transform.position = Vector2.MoveTowards(
                    this.transform.position,
                    player.transform.position,
                    speed * Time.deltaTime
                ); // Mueve hacia el jugador
            }
        }
    }
}

