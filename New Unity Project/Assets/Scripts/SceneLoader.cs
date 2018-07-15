using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//This script manages teh scenes
public class SceneLoader : MonoBehaviour {
    //This loads the game from the menu
    public void loadGame(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    //This loads the settings from the menu
    public void loadSettings()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 2);
    }
    //This loads the menu no matter where it is called
    public void loadMenu(){
        SceneManager.LoadScene(0);
    }
}
