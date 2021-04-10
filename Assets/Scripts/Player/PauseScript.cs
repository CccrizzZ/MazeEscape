using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PauseScript : MonoBehaviour
{
    // flag for paused
    public bool isPaused;

    // ui
    public GameObject PauseUI;
    public Canvas CanvasRef;
    GameObject PauseUIInstance;

    // references
    PlayerCamera P_Cam;
    PlayerMovement P_Move;



    void Start()
    {
        isPaused = false;
        PauseUIInstance = null;
        
        P_Cam = GetComponent<PlayerCamera>();
        P_Move = GetComponent<PlayerMovement>();
    }


    void OnPause(InputValue input)
    {
        if (input.Get().ToString() == "1")
        {
            isPaused = !isPaused;
            print(isPaused);

            // if no pause ui, instantiate it, if have pause ui, destroy it
            if (PauseUIInstance == null && Time.timeScale == 1)
            {
                PauseGame();
            }
            else
            {
                Unpause();
            }
        }
    }


    void PauseGame()
    {
        // launch pause menu ui
        PauseUIInstance = Instantiate(PauseUI, CanvasRef.transform);

        // disable camera
        P_Cam.SetCameraFreeze();
        P_Move.canMove = false;

        // set time scale
        Time.timeScale = 0;

    }

    public void Unpause()
    {
        // destroy pause menu ui
        Destroy(PauseUIInstance);

        // set camera active
        P_Cam.SetCameraMove();
        P_Move.canMove = true;

        // set time scale
        Time.timeScale = 1;

    }

}
