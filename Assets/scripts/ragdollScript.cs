using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollScript : MonoBehaviour
{
    private Animator anim;
    [Header("huesos y rigibody para ragdoll")]
    public Collider[] colliders;
    public Rigidbody[] rigibodys;

   // [Header(" componentes necesarios para animacion")]
    private Collider capsuleCollider;
    private Rigidbody rbPersonaje;


    public bool enable;
    private void Awake()
    {
        capsuleCollider = GetComponentInChildren<Collider>();
        rbPersonaje = GetComponentInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        activarRagdollFuncion(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            enable = !enable;
            if(enable)
            {
                Debug.Log("Ragdoll activado");
                activarRagdollFuncion( enable);
            }
            else
            {
                Debug.Log("ragdoll desactivado");
                activarRagdollFuncion( enable);
            }
        }
    }

    public void activarRagdollFuncion(bool enab)
    {
        capsuleCollider.enabled = !enab;
        rbPersonaje.isKinematic = enab;
        anim.enabled = !enab;

        foreach (Collider col in colliders)
        {
            col.enabled = enab;
        }

        foreach(Rigidbody rb in rigibodys)
        {
            rb.isKinematic = !enab;
        }

    }

  
}
