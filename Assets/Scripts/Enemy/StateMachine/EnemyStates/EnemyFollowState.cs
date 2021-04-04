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

        // play moving animation
        // E_Component.E_Animator.SetFloat(MovementHash, E_Component.E_NavMesh.velocity.normalized.z * 10);
        E_Component.E_Animator.SetFloat(MovementHash, 1.0f);

        // get distance between enemy and target
        DeltaDistance = Vector3.Distance(E_Component.transform.position, FollowTarget.transform.position);

        // Debug.Log(DeltaDistance);
        // if distance in stop distance range
        if (DeltaDistance < 2)
        {
            StateMachine.GotoState(EnemyStateType.Attack);
        }


    
    }



}
