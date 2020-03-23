using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player2" && player1.Instance.ataquedisp )
        {
            Debug.Log("espada toco a personaje 2");
            //player1.Instance.atacando = true;
            player1.Instance.ataque();
          
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player2")
        {
            player1.Instance.ataquedisp = false;
           // StartCoroutine(espera());
            

            Debug.Log("espada salio del personaje 2");
        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.3f);
        //player1.Instance.ataquedisp = false;
    }
}
