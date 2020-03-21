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
    void Awake()
    {

        //ALMACENA INSTANCIA
        //Cualquier script puede usar este gamemanager usando gameController.Instance
        if (Instance != null)
            Destroy(Instance);
        Instance = this;

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
