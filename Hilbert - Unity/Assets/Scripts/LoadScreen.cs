using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public int waitTime; //Delay in changing Scenes
    public void LoadScene(string sceneName){
        //Add Animation here if needed
        StartCoroutine(WaitForSceneLoad(sceneName));
    }
    private IEnumerator WaitForSceneLoad(string sceneName){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
