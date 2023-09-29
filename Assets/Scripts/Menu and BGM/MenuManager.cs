using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : SingletonMonobehaviour<MenuManager>
{
    
    public void GameStart()
    {
        SceneManager.LoadSceneAsync(1);
        SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
    }
    
    public void GameContinue()
    {
        
    }
    
    public void GameQuit()
    {
        Application.Quit();
    }
}
