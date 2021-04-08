using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    

    
    void Start()
    {

        // for collision test
        transform.position += new Vector3(0.05f, 2 ,0);

    }

    
    void Update()
    {
        // rotate the key
        transform.Rotate(0f, 1f, 0f);



    }


    void OnCollisionStay(Collision other) 
    {

        if (other.gameObject.CompareTag("Wall"))
        {
            print("reposition key");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Wall"))
        {
            print("reposition key");
            Destroy(gameObject);
        }
        
        
        // if overlaps player, add player keycount
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerStatus>().AddKey();
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>().PlayKeySound();

            Destroy(gameObject);    
        }



    }    
    



}
