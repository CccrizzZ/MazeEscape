using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pickup;

public class MedScript : PickupBase
{



    public int HealthPoint;

    private void Start()
    {
        print(name);

        // set pickup type
        Type = PickupType.MEDS;
    }


    override public void Pickup()
    {
        base.Pickup();

        switch (name)
        {
            case"FirstAid":
                // add health
                print(PlayerRef.GetComponent<PlayerStatus>().Health);
                if (PlayerRef.GetComponent<PlayerStatus>().Health < 100)
                {
                    PlayerRef.GetComponent<PlayerStatus>().setHealth(HealthPoint);
                    Destroy(gameObject);   
                }
                break;
            default:
                break;
        }

        // play sound effect


    }

}
