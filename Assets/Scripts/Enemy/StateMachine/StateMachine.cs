using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public State CurrState;

    Dictionary<EnemyStateType, State> States;

    bool running;


    void Awake()
    {
        running = false;

        // init the states dictionary
        States = new Dictionary<EnemyStateType, State>();
    
    }


    // init function
    // set the starting state of an enemy
    // if no states input, gointo idle state
    public void Init(EnemyStateType StartingState)
    {
        if(States.ContainsKey(StartingState))
        {
            GotoState(StartingState);
        }
        else if (States.ContainsKey(EnemyStateType.Idle))
        {
            GotoState(EnemyStateType.Idle);
        }
    }



    // add state function
    // add key-type and velue-state into the states dictionary
    // dont add if already existed
    public void AddState(EnemyStateType type, State state)
    {
        if (!States.ContainsKey(type)) 
        {
            States.Add(type, state);
        }
    }



    // remove state function
    // if states dictionary contains that type, delete it
    public void DeleteState(EnemyStateType type)
    {
        if (States.ContainsKey(type))
        {
            States.Remove(type);
        }
    }


    // goto state function
    // stop running the current state
    // dont go if no target in states dictionary
    // else start that state and its interval update
    public void GotoState(EnemyStateType target)
    {
        // Debug.Log(target);
        

        if (running)
        {
            // print("StateStopped");
            StopState(); 
        }

        if (States.ContainsKey(target))
        {
            CurrState = States[target];

            CurrState.Start();

            if (CurrState.UpdateInterval > 0)
            {
                InvokeRepeating(nameof(IntervalUpdate), 0.0f, CurrState.UpdateInterval);
            }

            running = true;
        }
    }



    // stop everything for current state
    public void StopState()
    {
        running = false;
        CurrState.Exit();
        CancelInvoke(nameof(IntervalUpdate));
    }




    // interval update's interval is determined in each state
    void IntervalUpdate()
    {
        if (running)
        {
            CurrState.IntervalUpdate();    

            // print(CurrState);
        }
    }



    void Update()
    {
        if (running)
        {
            CurrState.Update();
        }        
    }



    // void FixedUpdate()
    // {
    //     if (running)
    //     {
    //         CurrState.FixedUpdate();
    //     }
    // }




}


