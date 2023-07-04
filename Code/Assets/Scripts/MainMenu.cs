using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public string playScene;
    public string creditsScene;
    public string instrScene;
    public string mainScene;
    public void PlayGame() {
        SceneManager.LoadScene(playScene);
    }
    public void QuitGame() {
        Application.Quit();

    }
    public void CreditsScene() {
        SceneManager.LoadScene(creditsScene);
    }
    public void InstructionScene(){
        SceneManager.LoadScene(instrScene);
    }
    public void MenuScene() {
        SceneManager.LoadScene(mainScene);
    }
}
