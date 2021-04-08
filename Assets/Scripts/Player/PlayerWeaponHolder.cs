using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using WeaponScript;

public class PlayerWeaponHolder : MonoBehaviour
{
    // attacking sound effects
    public AudioSource AS_slash;
    public AudioSource AS_hit;

    // reference
    public PlayerMovement P_move;
    public Animator P_AnimController;
    public PlayerStatus P_Status;
    
    // ui
    Text CurrWeaponText;
    Text DamageText;


    // current weawpon held by player
    GameObject CurrentWeapon;
    WeaponInfo CurrentWeaponInfo;
    ToolScript CurrentWeaponTScript;

    
    // player start weapon
    public GameObject InitWeapon;
    

    // used to stop animation and damage
    bool IsAttacking;


    // damage = weapon damage * power
    public int power;

    bool canplay = false;
    bool alreadyplayed = false;


    void Start()
    {
        power = 1;
        IsAttacking = false;
        CurrWeaponText = GameObject.FindGameObjectWithTag("CurrWeaponText").GetComponent<Text>();
        DamageText = GameObject.FindGameObjectWithTag("DamageText").GetComponent<Text>();


        // set init weapon transform
        // SetWeaponCoreTransform(InitWeapon);
        
        // set transform
        // InitWeapon.transform.position = Vector3.zero;
        // InitWeapon.transform.localRotation = Quaternion.Euler(-transform.forward);

        // spawn new weapon
        // SpawnWeapon(InitWeapon);
        GameObject temp = Instantiate(InitWeapon);
        temp.name = temp.name.Replace("(Clone)", "");

        PickupWeapon(temp);
        
        Destroy(temp);

    }


    void Update()
    {
        if (P_AnimController.GetCurrentAnimatorStateInfo(1).IsName("Melee"))
        {
            canplay = false;
        }
        else
        {
            canplay = true;
        }
    } 





    void OnFire(InputValue pressed)
    {
        if(P_Status.Health <= 0) return; 

        // if holding melee weapon
        if(CurrentWeaponInfo.type == WeaponType.melee)
        {
            if (pressed.Get().ToString() == "1")
            {

                P_AnimController.SetBool("IsMelee", true);

                if (P_AnimController.GetCurrentAnimatorStateInfo(1).IsName("Melee") && !alreadyplayed)
                {
                    AS_slash.Play();
                    alreadyplayed = true;
                }

                StartCoroutine(StopAnimationAfterZeroPointOneSecond());
            }

        }
        
        // if(CurrentWeaponInfo.type == WeaponType.throwable)
        // {
            

        // }
        
    }

    // stop attacking
    IEnumerator StopAnimationAfterZeroPointOneSecond()
    {
        IsAttacking = true;    
        yield return new WaitForSeconds(0.01f);
        P_AnimController.SetBool("IsMelee", false);
        IsAttacking = false;
        alreadyplayed = false;


    }


    void OnTriggerEnter(Collider other)
    {



        if (!CurrentWeaponInfo) return;
        if (CurrentWeaponInfo.type == WeaponType.melee)
        {
            if (other.gameObject.tag != "Enemy") return;
            if (!P_AnimController.GetCurrentAnimatorStateInfo(1).IsName("Melee")) return;

            if (other.gameObject.GetComponent<EnemyScript>().Health > 0)
            {
                // dealth damage to enemy
                other.gameObject.GetComponent<EnemyScript>().SetHealth(-CurrentWeaponInfo.Damage * power);
                print(-CurrentWeaponInfo.Damage * power);

                // play sound effect
                AS_hit.Play();
            }
            
            // add force to enemy
            other.gameObject.GetComponent<Rigidbody>().AddForce(P_move.gameObject.transform.forward * 2,ForceMode.Impulse);

        }
    }




    public void DropWeapon()
    {
        // enable rigid body and collider
        CurrentWeapon.GetComponent<ToolScript>().SetRigidBodyAndCollider(true);

        // detach from parent
        CurrentWeapon.transform.parent = null;
        
        // set tag
        CurrentWeaponTScript.setPickedup(false);
        
        // set to null
        CurrentWeapon = null;
        CurrentWeaponInfo = null;
        CurrentWeaponTScript = null;
    }


    void SpawnWeapon(GameObject weapon)
    {
        // spawn weapon
        CurrentWeapon = Instantiate(weapon, transform);
        CurrentWeaponInfo = CurrentWeapon.GetComponent<WeaponInfo>();
        CurrentWeaponTScript = CurrentWeapon.GetComponent<ToolScript>();

        // set ui
        CurrWeaponText.text = weapon.name.Replace("weapon_", "");
        DamageText.text = weapon.GetComponent<WeaponInfo>().Damage.ToString();
    }


    public void PickupWeapon(GameObject NewWeapon)
    {
        // drop old weapon
        if (CurrentWeapon)
        {
            DropWeapon();
        }
        
        // disable rigidbody and collider
        NewWeapon.GetComponent<ToolScript>().SetRigidBodyAndCollider(false);

        // set tag
        NewWeapon.GetComponent<ToolScript>().setPickedup(true);

        // set transform
        NewWeapon.transform.position = Vector3.zero;
        NewWeapon.transform.localRotation = Quaternion.Euler(-transform.forward);

        // set new weapon core transform
        SetWeaponCoreTransform(NewWeapon);

        // spawn new weapon
        SpawnWeapon(NewWeapon);

        if (NewWeapon.transform.parent)
        {
            if (!(NewWeapon.transform.parent.name == "WeaponHolder"))
            {
                // destroy on ground weapon
                Destroy(NewWeapon);
                
            }
            
        }


        
        
    }   


    void SetWeaponCoreTransform(GameObject weapon)
    {
        // set core transform
        weapon.GetComponent<ToolScript>().core.transform.localRotation = Quaternion.Euler(Vector3.zero);
        weapon.GetComponent<ToolScript>().core.transform.position = weapon.GetComponent<ToolScript>().InHandPosition;
        weapon.GetComponent<ToolScript>().core.transform.localRotation = Quaternion.Euler(weapon.GetComponent<ToolScript>().InHandRotation);
        

    }




}
