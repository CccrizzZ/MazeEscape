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
        // print(name);

        // set pickup type
        Type = PickupType.MEDS;
    }


    override public void Pickup()
    {
        base.Pickup();

        

        switch (name)
        {
            case "FirstAid":

                // if player health full, ignore
                if (PlayerStatusRef.Health < 100)
                {
                    PlayerStatusRef.setHealth(HealthPoint);
                    Destroy(gameObject);   
                }

                break;
            case "Pill":
                // activate addied mode
                PlayerStatusRef.StartAddy();

                Destroy(gameObject);   
                // if player health full, ignore
                if (PlayerStatusRef.Health < 100)
                {
                    PlayerStatusRef.setHealth(HealthPoint);
                }

                break;
            default:
                break;
        }

        // play sound effect


    }

}


