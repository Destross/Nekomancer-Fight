using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearObjeto : MonoBehaviour
{
    public GameObject objetoPrefab; // El prefab del objeto que se creará

    void Update()
    {
        // Verificar si se hace clic en la escena con el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Obtener la posición del clic en la pantalla
            Vector3 posicionClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionClic.z = 0f; // Establecer la coordenada z en 0 para que el objeto se cree en el plano 2D

            // Crear el objeto en la posición del clic
            Instantiate(objetoPrefab, posicionClic, Quaternion.identity);
        }
    }
}

