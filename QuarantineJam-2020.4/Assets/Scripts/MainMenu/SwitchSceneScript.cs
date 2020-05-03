using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour
{   
    public string mainMenuSceneName = "MainMenu";
    public string levelSceneName = "LevelScene";
    
    public void LoadLevelScene(){
        SceneManager.LoadScene(levelSceneName);
    }
    
    public void LoadMainMenuScene(){
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
