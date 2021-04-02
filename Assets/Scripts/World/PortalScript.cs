using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    


    public GameObject parent;
    void Start()
    {

        // // for collision test
        parent.transform.position += new Vector3(1f, 0 ,1f);

    }

    void Update()
    {
        // transform.Rotate(new Vector3(0,0.001f,0) * Time.deltaTime);


    }


    IEnumerator CollisionTest()
    {

        yield return new WaitForSeconds(1);
        
        parent.transform.position -= new Vector3(1f, 0 ,1f);
    }

    // destroy portal if it overlaps wall
    void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(parent);
            print("please reposition portal");
        }    
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(parent);
            print("please reposition portal");
        }    
    }



}
