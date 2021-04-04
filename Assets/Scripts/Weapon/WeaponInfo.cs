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
            WeaponName = gameObject.name;
            print(WeaponName);
        }

        void Update()
        {
            
        }
    }

}