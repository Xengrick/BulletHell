using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int saludMaxima = 10; // Salud m�xima del jefe
    private int saludActual; // Salud actual del jefe

    public GameObject balaPrefab; // Prefab de la bala
    public float velocidadBala; // Velocidad de la bala

    private int numBalas; // N�mero de balas a disparar
    private float anguloEntreBalas; // �ngulo entre cada bala en grados

    private float densidadEspiral; // Densidad de la espiral (radio entre las vueltas)
    private float anguloEspiralOffset; // Desplazamiento inicial del �ngulo de la espiral
    private float anguloEspiralStep; // Incremento del �ngulo entre cada bala

    void Start()
    {
        saludActual = saludMaxima;

        // invoca sus ataques cada dos segundos
        InvokeRepeating("patronAtaque", 2f, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisi�n detectada");
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Reduce la salud del jefe
            saludActual--;

            // Verifica si la salud del jefe ha llegado a cero
            if (saludActual <= 0)
            {
                // Si la salud ha llegado a cero, destruye el objeto del jefe
                Destroy(gameObject);
            }
        }
    }

    public void patronAtaque()
    {

        // Genera un n�mero aleatorio entre 1 y 2
        int randomNumber = Random.Range(1, 5); // El valor m�ximo (3) es exclusivo
        
        switch(randomNumber) {
            case 1:
                patronUno();
                break;
            case 2:
                patronDos();
                break;
            case 3:
                StartCoroutine(patronTres());
                break;
            case 4:
                patronCuatro();
                break;

        }
    }

    public void patronUno()
    {
        anguloEntreBalas = 100;
        numBalas = 10;

        // Calcula el �ngulo inicial para la primera bala
        float anguloInicial = transform.eulerAngles.z;

        // Calcula el �ngulo entre cada bala
        float anguloIncremental = anguloEntreBalas / (numBalas - 1);

        // Itera sobre el n�mero de balas a disparar
        for (int i = 0; i < numBalas; i++)
        {
            // Calcula el �ngulo para esta bala
            float anguloBala = anguloInicial - (anguloEntreBalas / 2) + (anguloIncremental * i);

            // Calcula la direcci�n de la bala
            Vector2 direccionBala = Quaternion.Euler(0, 0, anguloBala) * Vector2.down;

            crearBala(direccionBala);
        }
    }

    public void patronDos()
    {
        anguloEntreBalas = 60;
        numBalas = 5;

        // Calcula el �ngulo inicial para la primera bala
        float anguloInicial = transform.eulerAngles.z;

        // Calcula el �ngulo entre cada bala
        float anguloIncremental = anguloEntreBalas / (numBalas - 1);

        // Itera sobre el n�mero de balas a disparar
        for (int i = 0; i < numBalas; i++)
        {
            // Calcula el �ngulo para esta bala
            float anguloBala = anguloInicial - (anguloEntreBalas / 2) + (anguloIncremental * i);

            // Calcula la direcci�n de la bala
            Vector2 direccionBala = Quaternion.Euler(0, 0, anguloBala) * Vector2.down;

            crearBala(direccionBala);
        }
    }

    public IEnumerator patronTres()
    {
        densidadEspiral = 0.2f;
        anguloEspiralOffset = 0f;
        anguloEspiralStep = 5f;
        numBalas = 10;

        float angulo = anguloEspiralOffset;

        for (int i = 0; i < numBalas; i++)
        {
            // Calcula la posici�n de la bala en la espiral
            float x = Mathf.Cos(angulo) * densidadEspiral * i;
            float y = Mathf.Sin(angulo) * densidadEspiral * i;
            Vector3 posicionSpawn = transform.position + new Vector3(x, y - 2f, 0f);


            // Instancia la bala en la posici�n calculada
            GameObject bullet = Instantiate(balaPrefab, posicionSpawn, Quaternion.identity);

            // Obt�n el componente Rigidbody2D de la bala y aplica una velocidad
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = (posicionSpawn - transform.position).normalized * velocidadBala;

            // Incrementa el �ngulo para la siguiente bala
            angulo += Mathf.Deg2Rad * anguloEspiralStep;

            yield return null;
        }
    }

    public void patronCuatro()
    {
        anguloEntreBalas = 60; // �ngulo entre cada bala
        numBalas = 5; // N�mero total de balas a disparar
        float tiempoEntreOndas = 0.5f; // Tiempo entre cada onda de balas
        int numOndas = 5; // N�mero total de ondas

        // Calcula el �ngulo inicial para la primera onda
        float anguloInicial = transform.eulerAngles.z;

        // Itera sobre el n�mero de ondas
        for (int i = 0; i < numOndas; i++)
        {
            // Calcula el �ngulo para esta onda
            float anguloOnda = anguloInicial + (360f / numOndas) * i;

            // Calcula la direcci�n de la onda
            Vector2 direccionOnda = Quaternion.Euler(0, 0, anguloOnda) * Vector2.down;

            // Llama a la funci�n para disparar una onda
            StartCoroutine(DispararOnda(direccionOnda, tiempoEntreOndas * i));
        }
    }

    private IEnumerator DispararOnda(Vector2 direccionOnda, float retraso)
    {
        yield return new WaitForSeconds(retraso);

        // Itera sobre el n�mero de balas a disparar en esta onda
        for (int i = 0; i < numBalas; i++)
        {
            // Calcula el �ngulo para esta bala en la onda
            float anguloBala = Mathf.Lerp(-anguloEntreBalas / 2, anguloEntreBalas / 2, (float)i / (numBalas - 1));

            // Calcula la direcci�n de la bala
            Vector2 direccionBala = Quaternion.Euler(0, 0, anguloBala) * direccionOnda;

            // Crea la bala en la posici�n del jefe
            crearBala(direccionBala);
        }
    }

    public void crearBala(Vector2 direccionBala)
    {
        // Instancia una nueva bala en la posici�n del jefe
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

        // Obt�n el componente Rigidbody2D de la bala
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();

        // Aplica una velocidad a la bala en la direcci�n calculada
        rbBala.velocity = direccionBala * velocidadBala;
    }
}
        

