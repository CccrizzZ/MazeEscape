using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    public int clock_seconds;

    int time_limit = 120;

    bool activated;


    PlayerStatus P_Status;

    void Start()
    {
        // player status
        P_Status = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();

        // init clock
        clock_seconds = time_limit;
        GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>().text = clock_seconds.ToString();
        activated = true;
        
    }

    void Update()
    {
        if (Time.frameCount % 120 == 0 && activated && P_Status.Health > 0 && Time.timeScale == 1)
        {
            if (clock_seconds > 0)
            {
                // set timer and update ui
                clock_seconds--;
                GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>().text = clock_seconds.ToString();
                
            }
            else
            {
                // call player death function
                P_Status.Death();


            }


        }
    }
}
