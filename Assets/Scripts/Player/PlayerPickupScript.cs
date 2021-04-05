using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Pickup;

public class PlayerPickupScript : MonoBehaviour
{

    PlayerStatus P_Status;
    PlayerWeaponHolder P_WeaponHolder;

    List<GameObject> NearbyPickups;

    GameObject TargetPickup;
    float prevDistance;


    // List<GameObject> AllPickups;

    void Start()
    {
        NearbyPickups = new List<GameObject>();

        P_Status = GetComponent<PlayerStatus>();
        P_WeaponHolder = P_Status.P_WeaponHolder;
    }

    void Update()
    {

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Pickups");
        if (temp.Length == 0) return;

        // if (!(NearbyPickups.Count > 0))
        // {
        //     foreach(var item in NearbyPickups)
        //     {
        //         if (!item.GetComponent<PickupBase>().canpickup)
        //         {
        //             NearbyPickups.Remove(item);
        //         }
        
        //         print(item.name);
        //     }
        // }

        
        // detect near by item and put them in list
        foreach (var item in temp)
        {
            // if (item.GetComponent<PickupBase>().canpickup && !NearbyPickups.Contains(item))
            // {
            //     NearbyPickups.Add(item);
            // }
            float distance = Vector3.Distance(item.transform.position, transform.position);
            if (distance < 3)
            {
                if (TargetPickup == null)
                {
                    TargetPickup = item;
                    prevDistance = distance;
                }
                else if(distance < prevDistance)
                {
                    TargetPickup = item;
                    prevDistance = distance;
                }
                
            }

        }

    }


    public void OnPickup(InputValue input)
    {
        // print("pickup");

        // get the nearest pickup
        // var temp = NearbyPickups[NearbyPickups.Count - 1];
        if (!TargetPickup) return;

        if (TargetPickup.GetComponent<PickupBase>().Type == PickupType.MEDS)
        {
            TargetPickup.GetComponent<MedScript>().Pickup();
            
        }
        else
        {
            
        }


    }


}
