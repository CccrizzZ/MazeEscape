using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStates
{

    GameObject FollowTarget;
    

    public EnemyAttackState(GameObject followTarget, EnemyScript e, StateMachine s) : base(e, s)
    {
        // set follow target and update interval
        FollowTarget = followTarget;
        UpdateInterval = 1.0f;

    }

    public override void Start()
    {
        // set weapon holder bool
        E_Component.E_WeaponHolder.IsAttacking = true;


        // stop navmesh and reset path
        E_Component.E_NavMesh.isStopped = true;
        E_Component.E_NavMesh.ResetPath();

        // stop movement animation and play attack animation
        E_Component.E_Animator.SetFloat(MovementHash, 0.0f);
        E_Component.E_Animator.SetBool(AttackHash, true);

    }



    public override void IntervalUpdate()
    {
        base.IntervalUpdate();

    }


    public override void Update()
    {
        // look at the follow target
        E_Component.transform.LookAt(FollowTarget.transform.position, Vector3.up);
        
        // get distance between self and follow target
        float DeltaDistance = Vector3.Distance(E_Component.transform.position, FollowTarget.transform.position);

        // if not in range, goto follow state
        if (DeltaDistance > MeleeAttackRange)
        {
            StateMachine.GotoState(EnemyStateType.Follow);
        }


        // if no health goto death state
        if (E_Component.Health <= 0)
        {
            StateMachine.GotoState(EnemyStateType.Dead);
        }

    }



    // set attack animation to false when exit
    public override void Exit()
    {
        base.Exit();
        E_Component.E_Animator.SetBool(AttackHash, false);

    }

}
