using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PickupScript : MonoBehaviour
{
    // pick up sfx
    public AudioSource pickupSound;

    // random list of item to generate
    public GameObject[] RandomCandidateArray;

    void Start()
    {
        // for collision test
        transform.position += new Vector3(0.05f, 10 ,0);

    }


    void OnCollisionEnter(Collision other)
    {
        // if player overlaps with the pickup
        if (other.gameObject.CompareTag("Player"))
        {
            
            // spawn random item
            var randint = Random.Range(0, RandomCandidateArray.Length);
            GameObject supply = Instantiate(RandomCandidateArray[randint]);
            
            print(supply.name);


            // set position
            if (supply.tag == "Enemy")
            {
                supply.GetComponent<NavMeshAgent>().enabled = false;
                supply.transform.position = other.gameObject.transform.position + other.gameObject.transform.forward;
                supply.GetComponent<NavMeshAgent>().enabled = true;

            }
            else
            {
                supply.transform.position = transform.position;

            }


            print(supply.transform.position);

            // get rid of the (clone) in name
            supply.name = supply.name.Replace("(Clone)", "");

            // destroy this box
            Destroy(this.transform.parent.gameObject);

        }

        // if overlaps wall, destroy
        if (other.gameObject.CompareTag("Wall"))
        {
            // print("Repositioned box");
            // destroy this box
            Destroy(this.transform.parent.gameObject);
        }
    }

}
