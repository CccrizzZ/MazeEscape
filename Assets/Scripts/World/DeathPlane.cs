using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        print("KILLED BY DEATHPLANE");
        Destroy(other.gameObject);
    }    


}
