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
        string WeaponName;
        public WeaponType type;

        int Damage;

        void Start()
        {
            
        }

        void Update()
        {
            
        }
    }

}