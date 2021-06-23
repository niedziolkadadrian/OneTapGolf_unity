using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHole : MonoBehaviour
{
    [SerializeField] GameObject gameState;
    void OnTriggerEnter2D(Collider2D other) {
        //when ball is in hole
        if(other.CompareTag("ball")){
            //update points;
            Points gamePoints = gameState.GetComponent<Points>();
            gamePoints.points+=1;
            gamePoints.updateField();
            
            //reset game
            GameStateMachine gStateM = gameState.GetComponent<GameStateMachine>();
            gStateM.ResetGame();
        }
    }
}