using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WeaponScript
{



    public enum WeaponType
    {
        melee,
        throwable,
        rifle
    }

    public class WeaponInfo : MonoBehaviour
    {
        public string WeaponName;
        public WeaponType type;

        public int Damage;

        void Start()
        {
            if (transform.parent)
            {
                if(transform.parent.name != "WeaponHolder")
                {
                    transform.localScale = new Vector3(1,1,1);
                }
                
            }

            WeaponName = gameObject.name;
            // print(WeaponName);
        }

        void Update()
        {
            
        }
    }

}