using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour{

	public float rotationAmount = 90f;
	public float rotationDuration = 0.5f;
	public float moveSpeed = 5f;
	public float jumpForce = 8f;
	public float siCamina = 0.2f;

	private float rotationStartTime;
	private float initialRotationZ;
	private float mHorizontal;
	private bool isRotate = false;
	private Rigidbody2D rb;
	private SpriteRenderer spi;
	private Animator anim;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		spi = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator>();
	}
	void Update () {

		mHorizontal = Input.GetAxis("Horizontal");
		
		if (Input.GetKeyDown(KeyCode.D))
		{
			spi.flipX = false;
			anim.SetBool("Camina", true);
        }
		
		if (Input.GetKeyDown(KeyCode.A))
		{
			spi.flipX = true;
			anim.SetBool("Camina", true);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
			rotationStartTime = Time.time;
			initialRotationZ = transform.rotation.eulerAngles.z;
			isRotate = true;
			Debug.Log("Rotando personaje: ");
		}

		if (Input.GetKeyUp(KeyCode.D))
		{
			spi.flipX = false;
			anim.SetBool("Camina", false);
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			spi.flipX = true;
			anim.SetBool("Camina", false);
		}
		if (isRotate)
        {
			float progress = (Time.time - rotationStartTime) / rotationDuration;
			float targetRotationZ = initialRotationZ + rotationAmount;
			float interpolatedRotationZ = Mathf.Lerp(initialRotationZ, targetRotationZ, progress);
			transform.rotation = Quaternion.Euler(0, 0, interpolatedRotationZ);
			Debug.Log("Procesando rotacion..." + progress);
			if (progress >= 1)
			{
				isRotate = false;
			}
		}
		rb.velocity = new Vector2(mHorizontal * moveSpeed, rb.velocity.y);
	}
} 
