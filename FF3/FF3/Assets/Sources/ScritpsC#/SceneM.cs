using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public static SceneM Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void ReloadScene() 
    { 
    int sceneID = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneID);
    }
    public void NextScene()
    {
        Time.timeScale = 1;
        int sceneID = SceneManager.GetActiveScene().buildIndex;
        
        sceneID++;
        SceneManager.LoadScene(sceneID);
    }
    public void LoadSceneWithId(int ID) 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(ID);

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
