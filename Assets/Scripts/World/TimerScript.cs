using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    int clock_seconds;

    int time_limit = 120;

    bool activated;


    void Start()
    {
        clock_seconds = time_limit;
        GameObject.FindGameObjectWithTag("TimerText").GetComponent<Text>().text = clock_seconds.ToString();
        activated = true;
        
    }

    void Update()
    {
        if (Time.frameCount % 120 == 0 && activated)
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
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().Death();


            }


        }
    }
}
