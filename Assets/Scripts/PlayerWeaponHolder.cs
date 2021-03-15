using UnityEngine;
using UnityEngine.InputSystem;
using WeaponScript;

public class PlayerWeaponHolder : MonoBehaviour
{

    public GameObject WeaponHolder;

    PlayerMovement pmove;
    Animator animController;
    GameObject CurrentWeapon;
    WeaponInfo CurrentWeaponInfo;
    bool isMelee;
    

    void Start()
    {
        isMelee = false;
        animController = GetComponent<Animator>();
        CurrentWeapon = WeaponHolder.transform.GetChild(0).gameObject;
        CurrentWeaponInfo = CurrentWeapon.GetComponent<WeaponInfo>();
        pmove = GetComponent<PlayerMovement>();
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
                animController.SetBool("IsMelee", true);   
                isMelee = true;
            }
            else
            {
                animController.SetBool("IsMelee", false);
                isMelee = false;
                
            }

        }
        
        if(CurrentWeaponInfo.type == WeaponType.throwable)
        {
            

        }
        
        // PlayerAnimator.SetBool(IsJumpingHash, value.isPressed);
    }


    void OnCollisionEnter(Collision other) 
    {
        
        // if (CurrentWeaponInfo.type == WeaponType.melee && isMelee)
        // {
        //     print(other.gameObject.name);
            
        // }    
    }

    void OnCollisionStay(Collision other) 
    {
        if (other.gameObject.tag != "Enemy") return;

        if (CurrentWeaponInfo.type == WeaponType.melee && isMelee)
        {
            print(other.gameObject.name);
            other.gameObject.GetComponent<Rigidbody>().AddForce(pmove.gameObject.transform.forward * 2,ForceMode.Impulse);
        }
    }

}
