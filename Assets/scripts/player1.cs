using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour {
	public static player1 Instance;
	[Header("variables vida")]
	public float vidaPj1 = 100f;

	[Header("variables mov")]
	public float moveSpeed = 5.0f; // velocidad
	public float moveSpeedRet = 3.0f; // velocidad retrocediendo
	public float jumpSpeed = 8.0f; // salto, cambia esta variable para saltar mas alto
	public float gravity = 20.0f; // salto, cambia esta variable para saltar mas alto
	public float rotationSpeed = 200.0f; //Rotacion camera sensibilidad
	public Animator anim;
	public float x,y;

	[Header("Daños")]
	public float dañoBasico1 = 2.5f;
	public float dañoEspecial = 10f;
	//public bool atacando;
	public bool ataquedisp;
	private float daño;
	void Awake()
	{
		//ALMACENA INSTANCIA
		//Cualquier script puede usar este gamemanager usando player1.Instance
		if (Instance != null)
			Destroy(Instance);
		Instance = this;

	}
	private void Start() {
		
		anim = GetComponent<Animator>();
		//atacando = true;
		ataquedisp = false;
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
		bool ataqueBasico = Input.GetKeyDown(KeyCode.F);
		bool ataqueEspecial = Input.GetKeyDown(KeyCode.R);

		if (ataqueBasico)
		{
			ataquedisp = true;
			anim.ResetTrigger("Atacar");
			anim.SetTrigger("Atacar");
			daño = dañoBasico1;
		
		}
		if(ataqueEspecial){
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

		if (vidaPj1 <= 0)
		{
			anim.ResetTrigger("muerto");
			anim.SetTrigger("muerto");
		}
		//-------------------------------------------------------------------
	}
	public void getHit(float daño)
	{
		vidaPj1 -= daño;
		anim.ResetTrigger("hit");
		anim.SetTrigger("hit");
	}
	public void  ataque()
	{

		//atacando = true;
		player2.Instance.getHit(daño);
		//StartCoroutine(Esperando(0.3f)); // esto es lo que dura la animacion de atacar
	}
	



}
