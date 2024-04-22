using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(1);
        }
    }

    private void takeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
                //gameOver();
                Invoke("dead",5.0f);
            }
        }
    }

    private void dead()
    {
        Destroy(gameObject);
    }

    private void gameOver()
    {
        // Encuentra todos los objetos en la escena con el tag especificado
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Recorre todos los objetos encontrados y destrúyelos
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
