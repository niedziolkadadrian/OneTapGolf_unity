using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject gameState;
    [SerializeField, Range(0,90)] float angle;
    [SerializeField] float initialVelocity;
    [SerializeField] float baseIncrement;
    [SerializeField] float incrementPerRound;
    [SerializeField] GameObject lineObj;
    private Rigidbody2D rb;
    private Vector2 forceVector;    //normalized vector in which ball will be throwed
    private Vector2 startLoc;       //start location of the ball       
    private List<GameObject> dots;  //list of dots in throw line
    private float throwVel=0;       //throw velocity
    private float acceleration;     //acceleration to the velocity
    private float radAngle;         //angle in radians
    private enum BallState{Initial, Throwing, Throw, Throwed};
    private BallState ballState;    //state of the ball

    private GameStateMachine gameStateMachine;

    // Start is called before the first frame update
    void Start()
    {
        //getting start location
        startLoc=(Vector2)transform.position;
        rb = GetComponent<Rigidbody2D>();
        //calculating angle in radians
        radAngle = angle* Mathf.Deg2Rad;
        //getting vector from angle
        forceVector = new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
        
        dots = new List<GameObject>();
        ResetBall();
    }

    void FixedUpdate() {
        //slowing down ball when grounded
        if(rb.velocity.y==0){
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x*0.95f-0.01f,0,rb.velocity.x),rb.velocity.y);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(ballState==BallState.Throwing){
            //update trajectory
            throwVel+=acceleration*Time.deltaTime;
            // getting gravityForce
            float G = -Physics2D.gravity.y;
            // calulating range
            float rangeX = Mathf.Pow(throwVel,2)/G * Mathf.Sin(2*radAngle);
            DrawThrowLine(throwVel,radAngle,rangeX);
            
            //throw if target outside of window
            if(startLoc.x + rangeX>9.0f)
                ballState=BallState.Throw;
        }
        if(ballState==BallState.Throw){
            //throw a ball
            DestroyLine();
            Throw();
            ballState=BallState.Throwed;
        }
        if(ballState==BallState.Throwed){
            //checking if ball out of map or stopped not in hole
            if(this.transform.position.x>9.0f || rb.velocity.x==0){
                GameStateMachine gameStateM = gameState.GetComponent<GameStateMachine>();
                gameStateM.ResetGame();
                //ending the game
                gameStateM.setState(new EndGameState(gameStateM));
            }
        }
    }

    //destroys line of dots
    void DestroyLine(){
        dots.ForEach(Destroy);
        dots.Clear();
    }

    //draws line of dots
    void DrawThrowLine(float initV, float rAngle, float rangeX){
        //Deleting previous line
        DestroyLine();
        // getting gravityForce
        float G = -Physics2D.gravity.y;
        // drawing dots
        for(float X=0.5f; X<=rangeX; X+=0.75f){
            float Y = X* Mathf.Tan(rAngle) - (G/(2*Mathf.Pow(initV,2)*Mathf.Pow(Mathf.Cos(rAngle),2)))*Mathf.Pow(X,2);
            GameObject dot = Instantiate(lineObj, new Vector3(X+startLoc.x, Y+startLoc.y, 0), Quaternion.identity);
            dots.Add(dot);
        }
    }

    public void StartThrow(){
        //if ballState was Initial then start Throwing
        if(ballState==BallState.Initial)
            ballState=BallState.Throwing;
    }

    public void EndThrow(){
        // if ballState was Throwing then Throw
        if(ballState==BallState.Throwing)
            ballState=BallState.Throw;
    }

    //Throws the ball
    void Throw(){
        rb.velocity = forceVector*throwVel;
    }
    //resets the position of the ball
    public void ResetBall(){
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
        this.transform.position = startLoc;
        ballState=BallState.Initial;
        acceleration= baseIncrement+incrementPerRound*gameState.GetComponent<Points>().points;
        throwVel=initialVelocity;
    }
}
