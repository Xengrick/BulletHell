using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerBehavior : MonoBehaviour
{
    public GameObject[] hearts;
    public int life;
    public AudioClip hitSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            audioSource.PlayOneShot(hitSound);
            takeDamage(1);
        }
    }

    public void takeDamage(int d)
    {
        if (life >= 1)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
      
            if (life < 1)
            {
                gameObject.GetComponent<Animator>().SetBool("isDead", true);
                Invoke("gameOver", 1.0f); 
            }
        }
    }

    public void gameOver()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}

