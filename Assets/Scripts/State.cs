using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected GameStateMachine stateMachine;
    public State(GameStateMachine stMachine){
        stateMachine=stMachine;
    }
    //Called when entering the state
    public virtual void StateStart(){}

    //called when left mouse button down
    public virtual void LmbDown(){}
    //called when left mouse button up
    public virtual void LmbUp(){}
}
