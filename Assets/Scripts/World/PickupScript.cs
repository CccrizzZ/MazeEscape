using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    public AudioSource pickupSound;

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
            supply.transform.position = transform.position;

            // destroy this box
            Destroy(this.transform.parent.gameObject);

        }

        // if overlaps wall, destroy
        if (other.gameObject.CompareTag("Wall"))
        {
            print("Repositioned box");
            // destroy this box
            Destroy(this.transform.parent.gameObject);
        }
    }

}
