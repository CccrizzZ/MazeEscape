using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowState : EnemyStates
{

    GameObject FollowTarget;

    float DeltaDistance;


    public EnemyFollowState(GameObject followTarget, EnemyScript e, StateMachine s) : base(e, s)
    {
        FollowTarget = followTarget;
        UpdateInterval = 1.0f;
    }


    public override void Start()
    {
        base.Start();
        // set navigation destination
        E_Component.E_NavMesh.SetDestination(FollowTarget.transform.position);

    }



    public override void IntervalUpdate()
    {
        base.IntervalUpdate();
        // set navigation destination
        E_Component.E_NavMesh.SetDestination(FollowTarget.transform.position);

    }



    
    
    
    public override void Update()
    {
        base.Update();

        // if no health goto death state
        if (E_Component.Health <= 0)
        {
            StateMachine.GotoState(EnemyStateType.Dead);
        }

        if(FollowTarget.GetComponent<PlayerStatus>().Health <= 0)
        {
            StateMachine.GotoState(EnemyStateType.Idle);
        }

        // get distance between enemy and target
        DeltaDistance = Vector3.Distance(E_Component.transform.position, FollowTarget.transform.position);

        // goto idle if player out of range
        if (DeltaDistance >= DetectionDistance)
        {
            StateMachine.GotoState(EnemyStateType.Idle);
        }


        // play moving animation
        // E_Component.E_Animator.SetFloat(MovementHash, E_Component.E_NavMesh.velocity.normalized.z * 10);
        E_Component.E_Animator.SetFloat(MovementHash, 1.0f);



        // Debug.Log(DeltaDistance);
        // if distance in stop distance range
        if (DeltaDistance < 2)
        {
            StateMachine.GotoState(EnemyStateType.Attack);
        }

    }


    // override public void Exit()
    // {
    //     base.Exit();
    //     E_Component.E_Animator.SetFloat(MovementHash, 0.0f);

    // }

}
