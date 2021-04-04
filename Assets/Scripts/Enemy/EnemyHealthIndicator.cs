using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthIndicator : MonoBehaviour
{

    public void SetHealthIndicatorColor(int currHealth)
    {
        if (currHealth <=0)
        {
            Destroy(gameObject);
        }

        // set health indicator color
        if (currHealth > 0 && currHealth <= 40)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if(currHealth > 40 && currHealth <= 70)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if(currHealth > 70 && currHealth <= 100)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

}
