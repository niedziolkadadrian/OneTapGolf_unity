using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [SerializeField] public Ball ball;
    [SerializeField] public HolePosition hole;

    [SerializeField] public CanvasGroup menuPanel;
    [SerializeField] public CanvasGroup pointsPanel;

    Points pts;
    State state;    //actual state
    // Start is called before the first frame update
    void Start()
    {
        pts=this.GetComponent<Points>();
        state=new GameState(this, ball);
    }

    // Update is called once per frame
    void Update()
    {
        //execute when LMB Down
        if(Input.GetMouseButtonDown(0)){
            state.LmbDown();
        }
        //execute when LMB Up
        else if(Input.GetMouseButtonUp(0)){
            state.LmbUp();
        }
    }
    //return Points object
    public Points getPoints(){
        return pts;
    }
    //sets new state
    public void setState(State state){
        this.state=state;
        this.state.StateStart();
    }
    //resets game (e.g. after scored point)
    public void ResetGame(){
        ball.ResetBall();
        hole.ResetHole();
    }
}
