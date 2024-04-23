using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullets : MonoBehaviour
{
    public float velocidad = 10f;
    private PlayerBehavior player; // Referencia al script PlayerBehavior

    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el GameObject del jugador y obtiene una referencia al script PlayerBehavior
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            player.takeDamage(1);
        }
    }

    void OnBecameInvisible()
    {
  
        Destroy(gameObject);
    }
}
