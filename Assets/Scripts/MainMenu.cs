using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //called in main menu start button
    public void OnStartButtonClicked(){
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");
    }
    //called in main menu quit button
    public void OnQuitButtonClicked(){
        Application.Quit();
    }
}
