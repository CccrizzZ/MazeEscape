using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : State
{


    protected int MovementHash = Animator.StringToHash("E_Movement");
    protected int AttackHash = Animator.StringToHash("IsAttacking");

    
    // follow stop distance
    protected float StopDistance = 2.3f;
    
    // melee attack range
    protected float MeleeAttackRange = 2.3f;

    // detection distance
    protected float DetectionDistance = 15;


    protected EnemyScript E_Component;

    public EnemyStates(EnemyScript e, StateMachine s) : base(s)
    {
        E_Component = e;
    }

}

public enum EnemyStateType
{
    Idle,
    Attack,
    Follow,
    Dead
}
