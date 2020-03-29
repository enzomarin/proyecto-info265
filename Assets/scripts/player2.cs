using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour {
	public static player2 Instance;
	[Header("variables vida")]
	public float vidapj2 = 150f;
	[Header("variables mov")]
	public float moveSpeed = 3.0f; // velocidad
	public float moveSpeedRet = 1.5f;
	public float jumpSpeed = 8.0f; // salto, cambia esta variable para saltar mas alto
	public float gravity = 20.0f; // salto, cambia esta variable para saltar mas alto
	public float rotationSpeed = 200.0f; //Rotacion camera sensibilidad
	public float x,y;
	public Animator anim;

	[Header("Daños")]
	public float dañoBasico1 = 2.5f;
	public float dañoEspecial = 10f;
	public bool atacando;
	public bool ataquedisp;
	private float daño;
	void Awake()
	{

		//ALMACENA INSTANCIA
		//Cualquier script puede usar este gamemanager usando player2.Instance
		if (Instance != null)
			Destroy(Instance);
		Instance = this;

	}
	private void Start() {
		anim = GetComponent<Animator>();
		ataquedisp = false;
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
				moveSpeed = 3.0f;
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
		bool ataquebasico = Input.GetKeyDown(KeyCode.H);
		bool ataqueEspecial = Input.GetKeyDown(KeyCode.Y);
		if (ataquebasico)
		{
			ataquedisp = true;
			anim.ResetTrigger("Atacar");
			anim.SetTrigger("Atacar");
			daño = dañoBasico1;

		}
		if (ataqueEspecial)
		{
			ataquedisp = true;
			anim.ResetTrigger("AtaqueEsp");
			anim.SetTrigger("AtaqueEsp");
			daño = dañoEspecial;

		}
		//--------------------------------------------------------------------------------


		// protegerse

		anim.SetBool("escudoIde",escudo);
		if(escudo && !correr){
			moveSpeed = 2f;
		}

	//----------------------------------------------------------------------------

	//------------------------ comprobando vida --------------------------
	if (vidapj2 <= 0)
	{
			anim.ResetTrigger("muerto");
			anim.SetTrigger("muerto");
	}
	//-------------------------------------------------------------------
	}
	public void getHit(float daño)
	{
		vidapj2 -= daño;
		anim.ResetTrigger("hit");
		anim.SetTrigger("hit");
	}
	public void ataque(){
		//atacando = true;
		
		player1.Instance.getHit(daño);
		ataquedisp = false;
		//StartCoroutine(Esperando(0.3f)); // esto es lo que dura la animacion de atacar
	}

}