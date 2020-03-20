using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {

	public float moveSpeed = 3.0f; // velocidad
	public float jumpSpeed = 8.0f; // salto, cambia esta variable para saltar mas alto
	public float gravity = 20.0f; // salto, cambia esta variable para saltar mas alto
	public float rotationSpeed = 200.0f; //Rotacion camera sensibilidad

	public float x,y;

	private Animator anim;
	private void Start() {
		anim = GetComponent<Animator>();
	}

	void Update () {
		bool correr= Input.GetKey(KeyCode.I);
	// movimiento del personaje
		anim.SetBool("run",correr);
		x = Input.GetAxis("Horizontal2");
		y = Input.GetAxis("Vertical2");
		transform.Rotate(0, x*Time.deltaTime * rotationSpeed,0);
		transform.Translate(0,0, y* Time.deltaTime * moveSpeed);

	//-------------------------------------

	// ataque
		bool atacar = Input.GetKeyDown(KeyCode.H);
		if (atacar)
		{
			ataque();
			anim.ResetTrigger("Atacar");
			anim.SetTrigger("Atacar");
		}
	//---------------------------


	}
	void ataque(){

	}
}