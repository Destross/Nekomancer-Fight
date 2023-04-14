using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public LayerMask groundLayer; // Capa que representa el suelo
    public Transform groundCheckPoint; // Punto de comprobaci�n del suelo
    public float groundCheckRadius = 0.1f; // Radio de comprobaci�n del suelo
    public bool isGrounded; // Variable para saber si el personaje est� en el suelo
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        // Realizar comprobaci�n de suelo
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {

            anim.SetBool("Pisando", true);
        }
        else
        {
            anim.SetBool("Pisando", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar gizmo para mostrar el punto de comprobaci�n del suelo en el editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }
}
