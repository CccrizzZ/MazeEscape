using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Pickup
{

    public enum PickupType
    {
        MEDS,
        TOOLS
    }

    public class PickupBase : MonoBehaviour
    {
        public AudioSource ASource;

        public PickupType Type;
        protected GameObject PlayerRef;
        
        float Distance;

        public bool canpickup;

        void Start()
        {
            // PlayerRef = GameObject.FindGameObjectWithTag("Player");

        }


        void Update()
        {   
            // set player reference
            if (PlayerRef == null)
            {
                PlayerRef = GameObject.FindGameObjectWithTag("Player");
            }

            // get to player distance
            Distance = Vector3.Distance(PlayerRef.transform.position, transform.position);

            // if far, return
            if(Distance > 3) 
            {
                canpickup = false;
                return;
            }

            // if close set canpickup to true
            canpickup = true;
            // print(Distance);

        }

        virtual public void Pickup()
        {
            if (!canpickup) return;
            

        }



    }
}