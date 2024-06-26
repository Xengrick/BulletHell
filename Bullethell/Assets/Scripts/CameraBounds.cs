using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public float characterWidth = 1f; // Ancho del personaje
    public float characterHeight = 1f; // Altura del personaje
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
      
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }

        if (mainCamera == null)
        {
            Debug.LogError("No se encontr� una c�mara con la etiqueta 'MainCamera'.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            
            float minX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).x + characterWidth / 2;
            float maxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, mainCamera.nearClipPlane)).x - characterWidth / 2;
            float minY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane)).y + characterHeight / 2;
            float maxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, mainCamera.nearClipPlane)).y - characterHeight / 2;

            Vector3 position = transform.position;

   
            position.x = Mathf.Clamp(position.x, minX, maxX);
            position.y = Mathf.Clamp(position.y, minY, maxY);

      
            transform.position = position;
        }
    }
}

