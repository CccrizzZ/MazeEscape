using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using WeaponScript;

public class PlayerWeaponHolder : MonoBehaviour
{


    public PlayerMovement P_move;
    public Animator P_AnimController;

    public PlayerStatus P_Status;


    // current weawpon held by player
    GameObject CurrentWeapon;
    WeaponInfo CurrentWeaponInfo;
    
    // player start weapon
    public GameObject InitWeapon;
    

    bool IsAttacking;


    void Start()
    {
        IsAttacking = false;


        // spawn start weapon
        CurrentWeapon = Instantiate(InitWeapon, transform);
        CurrentWeaponInfo = CurrentWeapon.GetComponent<WeaponInfo>();
    }


    void Update()
    {
        // print(isMelee);
    }





    void OnFire(InputValue pressed)
    {
        // if holding melee weapon
        if(CurrentWeaponInfo.type == WeaponType.melee)
        {
            if (pressed.Get().ToString() == "1")
            {
                
                P_AnimController.SetBool("IsMelee", true);
                StartCoroutine(StopAnimationAfterZeroPointOneSecond());
            }

        }
        
        // if(CurrentWeaponInfo.type == WeaponType.throwable)
        // {
            

        // }
        
    }


    IEnumerator StopAnimationAfterZeroPointOneSecond()
    {
        IsAttacking = true;
        yield return new WaitForSeconds(0.05f);
        P_AnimController.SetBool("IsMelee", false);
        IsAttacking = false;
    }


    void OnTriggerEnter(Collider other)
    {
        // play sound effect


        if (other.gameObject.tag != "Enemy") return;
        if (!IsAttacking) return;

        if (CurrentWeaponInfo.type == WeaponType.melee)
        {

            if (other.gameObject.GetComponent<EnemyScript>().Health > 0)
            {
                // dealth damage to enemy
                other.gameObject.GetComponent<EnemyScript>().SetHealth(-CurrentWeaponInfo.Damage);
                
            }
            
            // other.gameObject.GetComponent<Rigidbody>().AddForce(pmove.gameObject.transform.forward * 2,ForceMode.Impulse);

        }
    }

}
