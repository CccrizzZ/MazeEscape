
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pickup;


public class ToolScript : PickupBase
{

    public Vector3 InHandSize;
    public Vector3 InHandPosition;
    public Vector3 InHandRotation;
    public Vector3 OnGroundSize;

    public GameObject core;

    
    void Awake()
    {

        // get parent
        if (transform.parent != null )
        {
            if(transform.parent.name == "WeaponHolder")
            {
                // if in hand
                // print("Parent Weaponholder");
                // set transform
                SetRigidBodyAndCollider(false);
                setPickedup(true);
            }
            else
            {
                // if out of hand
                // print("no parent");
                SetRigidBodyAndCollider(true);
                setPickedup(false);

            }
        }
    }

    void Start()
    {
    
        // get rid of clone
        name = name.Replace("(Clone)", "");

        // set pickup type
        Type = PickupType.TOOLS;



    }


    void Update()
    {
        if (!core.gameObject)
        {
            print("core missing");
            Destroy(this);    
        }
    }



    override public void Pickup()
    {

    }

    public void setPickedup(bool picked)
    {
        // InHand
        if (picked)
        {
            this.tag = "Untagged";
            transform.localScale = InHandSize;
            
        }
        else // OnGround
        {
            this.tag = "Pickups";
            transform.localScale = OnGroundSize;


        }

    }





    public void SetRigidBodyAndCollider(bool enabled)
    {
        // set collider
        if (core.GetComponent<CapsuleCollider>())
        {
            core.GetComponent<CapsuleCollider>().enabled = enabled;
        }
        else if(core.GetComponent<BoxCollider>())
        {
            core.GetComponent<BoxCollider>().enabled = enabled;
        }


        if (enabled)
        {
            // deactive rigidbody
            core.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;    
        }
        else
        {
            // deactive rigidbody
            core.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        }

    }



}
