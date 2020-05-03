using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SwitchSceneScript : MonoBehaviour
{   
    public string mainMenuSceneName = "NormalLevel";
    public string levelSceneName = "MainMenu";
    
    public void LoadLevelScene(){
        SceneManager.LoadScene(levelSceneName);
    }
    
    public void LoadMainMenuScene(){
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
