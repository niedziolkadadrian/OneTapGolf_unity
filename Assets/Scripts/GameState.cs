using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : State
{
    Ball ball;
    public GameState(GameStateMachine stMachine, Ball ball): base(stMachine)
    {
        this.ball=ball;
    }
    public override void StateStart()
    {
        //turning off menuPanel
        stateMachine.menuPanel.alpha=0.0f;
        stateMachine.menuPanel.blocksRaycasts=false;
        stateMachine.menuPanel.interactable=false;
        
        //turning on pointsPanel
        stateMachine.pointsPanel.alpha=1.0f;
        stateMachine.pointsPanel.blocksRaycasts=true;
        stateMachine.pointsPanel.interactable=true;
    }

    public override void LmbDown()
    {
        //start throwing
        ball.StartThrow();
    }

    public override void LmbUp()
    {
        //end throwing
        ball.EndThrow();
    }
}
