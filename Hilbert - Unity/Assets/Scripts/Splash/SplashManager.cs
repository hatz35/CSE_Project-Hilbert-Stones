using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;


public class SplashManager : MonoBehaviour
{
    public Image xBackground;
    public string xNextSceneToLoad;
    public int xWaitingTime;
    public TextMeshProUGUI xLoaderText;

    public GameObject[] xStartingItems;
    public string[] xLoadingTexts;
    private static bool xNetworkReach;

    private void Awake()
    {
        StartCoroutine(LoadScene("Menu"));
        //Maybe call LoadScene from here only 
    }


    IEnumerator LoadScene(string SceneName)
    {
        xLoaderText.text = xLoadingTexts[0];
        yield return new WaitForSeconds((xWaitingTime-1)/3);
        xLoaderText.text = xLoadingTexts[1];
        xNetworkReach = IsConnected();
        yield return new WaitForSeconds((xWaitingTime - 1)/3);
        xLoaderText.text = xLoadingTexts[2];
        yield return new WaitForSeconds((xWaitingTime - 1)/3);
        Closer(xStartingItems);
        xBackground.CrossFadeAlpha(0f, 0.5f, false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneName);
    }

    public static bool IsConnected()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }

        return true;
    }

    private void Closer(GameObject[] objects)
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(false);
        }

    }
}
