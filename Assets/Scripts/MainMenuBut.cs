using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBut : MonoBehaviour
{
    //called in main menu start button
    public void OnMenuButtonClicked(){
        SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
    }
}
