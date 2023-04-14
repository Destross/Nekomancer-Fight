using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public Camera cam; // Referencia a la c�mara en tu escena

    void Update()
    {
        // Obt�n la posici�n del mouse en pantalla
        Vector3 mousePosition = Input.mousePosition;
        // Convierte la posici�n del mouse en pantalla a coordenadas del mundo
        Vector3 worldPosition = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, cam.nearClipPlane));

        // Verifica si est�s apuntando con el mouse en un objeto en la escena
        RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
        if (hit.collider != null)
        {
            // El mouse est� apuntando a un objeto en la escena
            Debug.Log("Apuntando a: " + hit.collider.name);
            // Puedes hacer algo con el objeto apuntado aqu�
        }
    }
}
