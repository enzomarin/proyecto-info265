using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player2.Instance.ataquedisp)
        {
            Debug.Log("hacha toco a personaje 1");
            
            player2.Instance.ataque();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player2")
        {
            player2.Instance.ataquedisp = false;
            // StartCoroutine(espera());


            Debug.Log("hacha salio del personaje 1");
        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(0.3f);
        //player1.Instance.ataquedisp = false;
    }
}
