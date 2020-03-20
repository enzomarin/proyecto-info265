using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour {

	public float moveSpeed = 5.0f; // velocidad
	public float moveSpeedRet = 3.0f; // velocidad retrocediendo
	public float jumpSpeed = 8.0f; // salto, cambia esta variable para saltar mas alto
	public float gravity = 20.0f; // salto, cambia esta variable para saltar mas alto
	public float rotationSpeed = 200.0f; //Rotacion camera sensibilidad

	private Animator anim;
	public float x,y;

	
	private void Start() {
		anim = GetComponent<Animator>();
	}
	void Update () {
		bool escudo = Input.GetKey(KeyCode.E);
	// movimiento del personaje
		bool correr = Input.GetKey(KeyCode.W);
		bool retroceder = Input.GetKey(KeyCode.S);
		bool girDer = Input.GetKey(KeyCode.D);
		bool girIzq = Input.GetKey(KeyCode.A);

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

		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");
		transform.Translate(0,0, y* Time.deltaTime * moveSpeed);
		transform.Rotate(0, x*Time.deltaTime * rotationSpeed,0);
		

	//-----------------------------------------------------------------------------

	// ------------------------------  Ataque  ---------------------------------------
		bool atacar = Input.GetKeyDown(KeyCode.F);
		bool ataqueEspecial = Input.GetKeyDown(KeyCode.R);
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
