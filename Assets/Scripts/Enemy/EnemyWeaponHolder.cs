using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponScript;

public class EnemyWeaponHolder : MonoBehaviour
{

    public GameObject[] WeaponList;

    GameObject CurrentWeapon;

    public bool IsAttacking;


    void Start()
    {
        // enemy's weapon will be random
        CurrentWeapon = Instantiate(WeaponList[Random.Range(0, WeaponList.Length)], transform);    
        print(CurrentWeapon.gameObject.name);
    }

    
    public void DropWeapon()
    {
        var temp = CurrentWeapon.transform.GetChild(0);
        if (temp.GetComponent<CapsuleCollider>())
        {
            temp.GetComponent<CapsuleCollider>().enabled = true;
        }
        else if(temp.GetComponent<BoxCollider>())
        {
            temp.GetComponent<BoxCollider>().enabled = true;
        }


        temp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        CurrentWeapon.transform.parent = null;
    }
    


    // takes player object and set its health
    void DealtDamageToPlayer(GameObject player)
    {
        player.GetComponent<PlayerStatus>().setHealth(-CurrentWeapon.gameObject.GetComponent<WeaponInfo>().Damage);
        print("Damage to Player: " + -CurrentWeapon.gameObject.GetComponent<WeaponInfo>().Damage);
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && IsAttacking)
        {
            DealtDamageToPlayer(other.gameObject);

        
        }

    }
}
