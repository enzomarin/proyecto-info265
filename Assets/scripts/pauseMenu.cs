using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool  gameIsPaused = false;// se puede utilizar esta variable en cualquier script usando pauseMenu.gameIsPaused
    public KeyCode pauseButton;// boton del teclado que se usara para poner el juego en pausa
    public GameObject  canvasPause;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            Debug.Log("se apreto el boton de pausa");
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }

    }

    public void resume(){
        canvasPause.SetActive(false);
        Time.timeScale= 1f;
        gameIsPaused=false;
    }

    public void pause(){
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}
