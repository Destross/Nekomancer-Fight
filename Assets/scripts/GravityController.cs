using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float gravity = 3f; // Gravedad normal del mundo en Unity

    void FixedUpdate()
    {
        // Obtén la rotación en el eje Z del objeto
        float rotationZ = transform.rotation.eulerAngles.z;

        // Calcula el vector de gravedad en función de la rotación en el eje Z
        Vector3 gravityDirection = Quaternion.Euler(0, 0, rotationZ) * Vector3.up;

        // Aplica la gravedad al objeto
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = gravityDirection.y * gravity;
    }
}

