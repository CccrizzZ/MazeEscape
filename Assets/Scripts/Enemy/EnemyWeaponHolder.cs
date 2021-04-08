using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponScript;

public class EnemyWeaponHolder : MonoBehaviour
{

    public AudioSource AS_hit;

    // list of random weapons
    public GameObject[] WeaponList;
    // current weapon on hand
    GameObject CurrentWeapon;
    // is attacking bool
    public bool IsAttacking;


    void Start()
    {
        // enemy's weapon will be random
        CurrentWeapon = Instantiate(WeaponList[Random.Range(0, WeaponList.Length)], transform);    
        CurrentWeapon.GetComponent<ToolScript>().setPickedup(true);
        // print(CurrentWeapon.gameObject.name);
    }

    // drop current weapon
    public void DropWeapon()
    {

        // set rigidbody
        CurrentWeapon.GetComponent<ToolScript>().SetRigidBodyAndCollider(true);
        // detach
        CurrentWeapon.transform.parent = null;
        // set tag
        CurrentWeapon.GetComponent<ToolScript>().setPickedup(false);
        // set null
        CurrentWeapon = null;

    }
    


    // takes player object and set its health
    void DealtDamageToPlayer(GameObject player)
    {
        player.GetComponent<PlayerStatus>().setHealth(-CurrentWeapon.gameObject.GetComponent<WeaponInfo>().Damage);
        print("Damage to Player: " + -CurrentWeapon.gameObject.GetComponent<WeaponInfo>().Damage);
        AS_hit.Play();
    }

    // dealt damage to player
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && IsAttacking)
        {
            IsAttacking = false;
            DealtDamageToPlayer(other.gameObject);

        }
    }



}
