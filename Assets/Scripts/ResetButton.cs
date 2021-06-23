using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    [SerializeField] GameObject gameState;
    public void OnResetButtonClicked(){
        //resetting points
        Points gamePoints=gameState.GetComponent<Points>();
        gamePoints.points = 0;
        gamePoints.updateField();
        
        //changing state to Game
        GameStateMachine gameStateM = gameState.GetComponent<GameStateMachine>();
        gameStateM.setState(new GameState(gameStateM, gameStateM.ball));
    }
}
