using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Pickup;

public class PlayerPickupScript : MonoBehaviour
{
    public AudioSource AS_pick;

    // player components
    PlayerStatus P_Status;
    PlayerWeaponHolder P_WeaponHolder;

    // pickup detection
    float DetectionRange;
    GameObject TargetPickup;
    float PrevDistance;


    // UIs
    Text PickupText;
    Text PickupNameText;

    void Start()
    {
        // player component
        P_Status = GetComponent<PlayerStatus>();
        P_WeaponHolder = P_Status.P_WeaponHolder;

        // init ui
        PickupText = GameObject.FindGameObjectWithTag("PickupText").GetComponent<Text>();
        PickupNameText = GameObject.FindGameObjectWithTag("PickupText").transform.GetChild(0).GetComponent<Text>();
        PickupText.gameObject.SetActive(false);


        // detection range for pickups
        DetectionRange = 3.0f;
    }

    void Update()
    {
        // if dead disable pickup system
        if (P_Status.Health <= 0)
        {
            TargetPickup = null;
            HideUI();
            return;
        }

        // detect all pickups
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Pickups");
        if (temp.Length <= 0) 
        {
            TargetPickup = null;
            HideUI();
            return;
        }


        // print(temp.Length);

        // get nearby pickup
        TargetPickup = GetNearestPickup(temp);
    
        // toggle ui
        if (!TargetPickup)
        {
            HideUI();
        }
        else
        {
            PickupText.gameObject.SetActive(true);
            PickupNameText.text = TargetPickup.name.Replace("weapon_", "");
        }

    }


    // hide ui
    void HideUI()
    {   

        PickupNameText.text = "";
        PickupText.gameObject.SetActive(false);
    }



    // get nearest pickup item
    GameObject GetNearestPickup(GameObject[] allPickups)
    {
        GameObject goMin = null;
        float minDist = Mathf.Infinity;
        foreach (var pickup in allPickups)
        {
            float dist = Vector3.Distance(pickup.transform.position, transform.position);
            if (dist < DetectionRange)
            {
                goMin = pickup;
                minDist = dist;
            }
        }
        return goMin;
    }


    
    public void OnPickup(InputValue input)
    {

        // get the nearest pickup
        if (!TargetPickup) return;


        // determine if pickup is med or weapon
        if (TargetPickup.GetComponent<PickupBase>().Type == PickupType.MEDS)
        {
            TargetPickup.GetComponent<MedScript>().Pickup();
        }
        else if (TargetPickup.GetComponent<PickupBase>().Type == PickupType.TOOLS)
        {
            P_WeaponHolder.PickupWeapon(TargetPickup);
        }
        AS_pick.Play();
    }


}
