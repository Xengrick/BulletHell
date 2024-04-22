using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocidad = 10f; //velocidad de la bala

    // Start is called before the first frame update
    void Start()
    {
        //obt�n la posici�n del cursor 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; //coordenada z sea cero para que est� en el mismo plano que el juego

        // calcula la direcci�n del proyectil
        Vector3 direction = (mousePosition - transform.position).normalized;

        // aplica la velocidad del proyectil
        GetComponent<Rigidbody2D>().velocity = direction * velocidad;
    }

    //colisi�n con un objeto
    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el proyectil colisiona con un enemigo
        if (other.CompareTag("Enemy"))
        {
            // destruye el proyectil
            Destroy(gameObject);
        }
    }

    //sale de la camara
    void OnBecameInvisible()
    {
        // destruye el proyectil
        Destroy(gameObject);
    }

}
