using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyStates
{

    public EnemyIdleState(EnemyScript e, StateMachine s) : base(e, s)
    {

    }


    
    public override void Start()
    {
        base.Start();

        E_Component.E_NavMesh.isStopped = true;
        E_Component.E_NavMesh.ResetPath();
        E_Component.E_Animator.SetFloat(MovementHash, 0.0f);
    }

}
