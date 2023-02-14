using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton Instantiation
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    //Restarts the level
    public void ResetLevel()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    //Loads the next level
    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    //Loads a specific level by the name of the scene
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Opens Mainmenu Scene
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
