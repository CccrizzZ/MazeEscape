using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalCollision : MonoBehaviour
{

        
    public Material unlockedMat;
    bool unlocked;


    void Start()
    {
        unlocked = false;
    }


    void Update()
    {


        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().KeyCount >= 3)
        {
            SetPortalColorToActive();
        }        
    }




    void SetPortalColorToActive()
    {
        GetComponent<Renderer>().material = unlockedMat;
        unlocked = true;
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && unlocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("EscapedScene");
        }

    }
}
