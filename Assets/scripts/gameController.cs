using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController Instance;
    public Canvas hud;
    public Canvas canvPause;

    public Text textV1;
    public Text textV2;
    void Awake()
    {

        //ALMACENA INSTANCIA
        //Cualquier script puede usar este gamemanager usando gameController.Instance
        if (Instance != null)
            Destroy(Instance);
        Instance = this;

    }
    


    // Update is called once per frame
    void Update()
    {
       textV1.text = "Vida pj1: "+ player1.Instance.vidaPj1;
       textV2.text = "Vida pj2: " + player2.Instance.vidapj2;
 
    }
}
