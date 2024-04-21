using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb2D;
    public GameObject projectilePrefab;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); // Obtén la referencia al Rigidbody2D
    }

    void Update()
    {
        // Resetea la velocidad para evitar acumulación de fuerzas
        rb2D.velocity = Vector2.zero;

        if (Input.GetKey("a"))
        {
            rb2D.AddForce(Vector2.left * velocidad, ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("left", true);
        }

        if (Input.GetKey("d"))
        {
            rb2D.AddForce(Vector2.right * velocidad, ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("right", true);
        }

        if (Input.GetKey("w"))
        {
            rb2D.AddForce(Vector2.up * velocidad, ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("up", true);
        }

        if (Input.GetKey("s"))
        {
            rb2D.AddForce(Vector2.down * velocidad, ForceMode2D.Impulse);
            gameObject.GetComponent<Animator>().SetBool("down", true);
        }

        if (Input.GetMouseButtonDown(0)) //mouse
        {
            //crea un projectil
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }

        //animación
        if(!Input.GetKey("w") && !Input.GetKey("s") && !Input.GetKey("a") && !Input.GetKey("d"))
        {
            gameObject.GetComponent<Animator>().SetBool("down", false);
            gameObject.GetComponent<Animator>().SetBool("up", false);
            gameObject.GetComponent<Animator>().SetBool("left", false);
            gameObject.GetComponent<Animator>().SetBool("right", false);
        }

    }
}
