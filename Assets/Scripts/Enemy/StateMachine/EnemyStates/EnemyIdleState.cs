using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStates
{

    GameObject FollowTarget;

    float DistanceToTarget;


    public EnemyIdleState(GameObject followTarget ,EnemyScript e, StateMachine s) : base(e, s)
    {
        FollowTarget = followTarget;
    }


    
    public override void Start()
    {
        base.Start();

        E_Component.E_NavMesh.isStopped = true;
        E_Component.E_NavMesh.ResetPath();
        E_Component.E_Animator.SetFloat(MovementHash, 0.0f);
    }

    public override void Update()
    {
        base.Update();
        
        E_Component.E_Animator.SetFloat(MovementHash, 0.0f);

        // stop if player is dead
        if (!(FollowTarget.GetComponent<PlayerStatus>().Health <= 0))
        {
            // if player in range, follow and attack
            DistanceToTarget = Vector3.Distance(E_Component.transform.position, FollowTarget.transform.position);
            if (DistanceToTarget <= DetectionDistance)
            {
                StateMachine.GotoState(EnemyStateType.Follow);
            }

        }


    }


}
