using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyScript : MonoBehaviour
{

    public int Health;
    public EnemyHealthIndicator E_HealthIndicator;

    public NavMeshAgent E_NavMesh { get; private set; }
    public Animator E_Animator { get; private set; }
    public StateMachine E_StateMachine { get; private set; }

    public EnemyWeaponHolder E_WeaponHolder;

    GameObject E_FollowTarget;
    

    // collider dead and alive
    public CapsuleCollider AliveCapsule;
    public CapsuleCollider DeadCapsule;



    private void Awake()
    {
        // set variables
        Health = 100;

        // get references
        E_NavMesh = GetComponent<NavMeshAgent>();
        E_Animator = GetComponent<Animator>();
        E_StateMachine = GetComponent<StateMachine>();
        
        
    }


    void Start()
    {
        // set follow target to player
        E_FollowTarget = GameObject.FindGameObjectWithTag("Player");
        
        // init state machine
        Init(E_FollowTarget);

    }

    void Update()
    {

    }


    public void Init(GameObject target)
    {  
        // set follow target
        E_FollowTarget = target;


        // register all states in state machine
        EnemyIdleState E_IdleState = new EnemyIdleState(E_FollowTarget, this, E_StateMachine);
        E_StateMachine.AddState(EnemyStateType.Idle, E_IdleState);

        EnemyAttackState E_AttackState = new EnemyAttackState(E_FollowTarget, this, E_StateMachine);
        E_StateMachine.AddState(EnemyStateType.Attack, E_AttackState);

        EnemyFollowState E_FollowState = new EnemyFollowState(E_FollowTarget, this, E_StateMachine);
        E_StateMachine.AddState(EnemyStateType.Follow, E_FollowState);

        EnemyDeadState E_DeadState = new EnemyDeadState(this, E_StateMachine);
        E_StateMachine.AddState(EnemyStateType.Dead, E_DeadState);


        // init state machine
        E_StateMachine.Init(EnemyStateType.Idle);


    }




    public void SetHealth(int input)
    {
        // clamp
        if (Health + input > 0)
        {
            // set health and set indicator color
            Health += input;
            E_HealthIndicator.SetHealthIndicatorColor(Health);

            // print(Health);
            
        }
        else if (Health + input <= 0)
        {
            Health = 0;
        }
        
        // drop dead and add kill to player
        if (Health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>().AddKill();    
        }


    }


    // swap collider upon death
    public void SwapAliveAndDeadCapsule()
    {
        // swap collision capsule
        E_NavMesh.enabled = false;
        AliveCapsule.enabled = false;
        DeadCapsule.enabled = true;

        // drop weapon
        DropWeapon();

        //  disable health indicator
        E_HealthIndicator.gameObject.SetActive(false);
    
    }

    // drop current weapon
    void DropWeapon()
    {
        E_WeaponHolder.DropWeapon();
    }

}
