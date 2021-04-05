using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerStatus : MonoBehaviour
{
    public int Health;
    int Stamina;
    public int KeyCount;
    public int KillCount;

    public PlayerWeaponHolder P_WeaponHolder;

    public CapsuleCollider InGameCollider;
    public CapsuleCollider DeathCollider;
    


    void Start()
    {
        KillCount = 0;
        KeyCount = 0;
        Health = 100;
        Stamina = 100;

        // init ui
        GameObject.FindGameObjectWithTag("KeyText").GetComponent<Text>().text = KeyCount.ToString();
        GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>().text = Health.ToString();
        GameObject.FindGameObjectWithTag("KillText").GetComponent<Text>().text = KillCount.ToString();

        // spawn player at random position
        // transform.position = new Vector3(Random.Range(-35, 56), -14f, Random.Range(30, 123));

    }

    



    void Update()
    {
        
    }


    public void AddKill()
    {
        KillCount++;
        GameObject.FindGameObjectWithTag("KillText").GetComponent<Text>().text = KillCount.ToString();

    }


    public void AddKey()
    {
        // add key count and update ui text
        KeyCount++;
        GameObject.FindGameObjectWithTag("KeyText").GetComponent<Text>().text = KeyCount.ToString();

    }


    public void setHealth(int input)
    {
        // dont set health if already dead
        if(Health <= 0) return;


        if (Health + input > 0)
        {
            if (input < 0)
            {
                // set health
                Health += input / 2;
            }
            else if (Health + input > 100)
            {
                Health = 100;
            }
            else
            {
                Health += input;

            }
            
        }
        else if (Health + input <= 0)
        {
            Health = 0;
            Death();

        }

        // update ui
        GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>().text = Health.ToString();


    }


    public void Death()
    {
        // clear health
        if(Health != 0)
        {
            Health = 0;
        }


        // disable player movement and look
        GetComponent<PlayerMovement>().canMove = false;
        GetComponent<PlayerCamera>().canLook = false;

        // play death animation
        GetComponent<Animator>().SetBool("IsDead", true);

        // disable capsule collider
        InGameCollider.enabled = false;
        DeathCollider.enabled = true;

        // play sound effect

        // load game over scene after 4 seconds
        StartCoroutine(GotoDeathScreen());


    }

    IEnumerator GotoDeathScreen()
    {
        // wait for animation to finish
        yield return new WaitForSeconds(4);

        // show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        // load scene
        SceneManager.LoadScene("GameOverScene");

    }


    public void Escaped()
    {
        // GM_FinalScore = 100;


        // play sound effect

        // load escaped scene
        SceneManager.LoadScene("EscapedScene");

    }
}
