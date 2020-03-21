using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {

	public float moveSpeed = 3.0f; // velocidad
	public float moveSpeedRet = 1.5f;
	public float jumpSpeed = 8.0f; // salto, cambia esta variable para saltar mas alto
	public float gravity = 20.0f; // salto, cambia esta variable para saltar mas alto
	public float rotationSpeed = 200.0f; //Rotacion camera sensibilidad

	public float x,y;

	private Animator anim;
	private void Start() {
		anim = GetComponent<Animator>();
	}

	void Update () {
		bool escudo = Input.GetKey(KeyCode.U);
	// movimiento del personaje
		bool correr = Input.GetKey(KeyCode.I);
		bool retroceder = Input.GetKey(KeyCode.K);
		bool girDer = Input.GetKey(KeyCode.J);
		bool girIzq = Input.GetKey(KeyCode.L);

		anim.SetBool("ret",retroceder);
		anim.SetBool("run",correr);
		anim.SetBool("girarDer",girDer);
		anim.SetBool("girarIzq",girIzq);
		if(retroceder){
			moveSpeed = moveSpeedRet;
		}
		else
		{
			if(!escudo){
				moveSpeed = 5.0f;
			}
			
		}

		x = Input.GetAxis("Horizontal2");
		y = Input.GetAxis("Vertical2");
		if(!escudo){
			transform.Translate(0,0, y* Time.deltaTime * moveSpeed);
			transform.Rotate(0, x*Time.deltaTime * rotationSpeed,0);
		}

		

	//-----------------------------------------------------------------------------

	// ------------------------------  Ataque  ---------------------------------------
		bool atacar = Input.GetKeyDown(KeyCode.H);
		bool ataqueEspecial = Input.GetKeyDown(KeyCode.Y);
		if (atacar)
		{	
			
			ataque();
			anim.ResetTrigger("Atacar");
			anim.SetTrigger("Atacar");
		}
		if(ataqueEspecial){
			// generar funcion atEspecial()
			anim.ResetTrigger("AtaqueEsp");
			anim.SetTrigger("AtaqueEsp");
		}
	//--------------------------------------------------------------------------------



	// protegerse
		
		anim.SetBool("escudoIde",escudo);
		if(escudo && !correr){
			moveSpeed = 2f;
		}


	//----------------------------------------------------------------------------
	
	}

	void ataque(){
		// codigo necesario para hacer daño etc.
	}
}