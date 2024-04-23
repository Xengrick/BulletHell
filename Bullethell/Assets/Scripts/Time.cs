using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public GameObject boss;
    private float puntaje;
    private TextMeshProUGUI textMesh;
    private bool bossCreado = false;

    // Start is called before the first frame update
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        boss.SetActive(false);
    }

    private void Update()
    {
        if (!bossCreado)
        {
            puntaje += Time.deltaTime;
            textMesh.text = puntaje.ToString("0");
        }

        if (puntaje >= 20f && !bossCreado)
        {
            bossCreado = true; 
            boss.SetActive(true);
        }
    }
}
