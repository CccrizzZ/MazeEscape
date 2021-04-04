using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyStates
{

    int DeathHash = Animator.StringToHash("IsDead");

    public EnemyDeadState(EnemyScript e, StateMachine s) : base(e, s)
    {

    }

    public override void Start()
    {
        base.Start();

        // stop navigation
        E_Component.E_NavMesh.isStopped = true;
        E_Component.E_NavMesh.ResetPath();

        E_Component.SwapAliveAndDeadCapsule();

        
        // set animation
        E_Component.E_Animator.SetFloat(MovementHash, 0.0f);
        E_Component.E_Animator.SetBool(DeathHash, true);


    }


    public override void Exit()
    {
        base.Exit();
        E_Component.E_NavMesh.isStopped = false;
        E_Component.E_Animator.SetBool(DeathHash, false);

    }


}
