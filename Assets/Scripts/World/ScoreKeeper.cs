using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreKeeper : MonoBehaviour
{

    int Kills;
    int TimeLeft;

    PlayerStatus P_Stat;
    TimerScript T_Script;

    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("ScoreKeeper");

        if (objects.Length > 1)
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);


    }


    void Start()
    {
        Kills = 0;
        TimeLeft = 0;
        
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            P_Stat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
            T_Script = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>();
        }        
    }


    void Update()
    {
        
        

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            Kills = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().KillCount;
            TimeLeft = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimerScript>().clock_seconds;
        }
        
        if (SceneManager.GetActiveScene().name == "GameOverScene")
        {
            GameObject.FindGameObjectWithTag("KillText").GetComponent<Text>().text = Kills.ToString();
        }
        
        if(SceneManager.GetActiveScene().name == "EscapedScene")
        {
            GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>().text = TimeLeft.ToString();
            GameObject.FindGameObjectWithTag("KillText").GetComponent<Text>().text = Kills.ToString();
            GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>().text = (Kills*100 + TimeLeft).ToString();
            
        }
    }
}
