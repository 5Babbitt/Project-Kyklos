using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public Scene currentScene;
    
    private void Start() 
    {
        currentScene = SceneManager.GetActiveScene();
    }

    public void OnReset()
    {
        SceneManager.LoadScene(currentScene.name);
    }
}
