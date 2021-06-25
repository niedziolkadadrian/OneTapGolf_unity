using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class EndGameState : State
{
    public EndGameState(GameStateMachine stMachine): base(stMachine){}

    public override void StateStart()
    {
        int best_score = 0 ;
        //reading best score from file if exists
        if(File.Exists("score.txt")){
            StreamReader reader = new StreamReader("score.txt");
            best_score = int.Parse(reader.ReadLine());
            reader.Close();
        }
        else{
            //creating file if not exists
            StreamWriter sw =File.CreateText("score.txt");
            sw.Write("0");
            sw.Close();
        }

        //getting actual score
        int score = stateMachine.getPoints().points;
        //printing text on canvas
        Text scoreTxt = stateMachine.menuPanel.transform.Find("Panel/ScoreText").GetComponent<Text>();
        scoreTxt.text = $"SCORE: {score} BEST:{best_score}";
        
        //saving new best score
        if(score>best_score){
            StreamWriter writer = new StreamWriter("score.txt");
            writer.Write(score.ToString());
            writer.Close();
        }

        //turning on menuPanel
        stateMachine.menuPanel.alpha=1.0f;
        stateMachine.menuPanel.blocksRaycasts=true;
        stateMachine.menuPanel.interactable=true;
        
        //turning off pointsPanel
        stateMachine.pointsPanel.alpha=0.0f;
        stateMachine.pointsPanel.blocksRaycasts=false;
        stateMachine.pointsPanel.interactable=false;
    }
}
