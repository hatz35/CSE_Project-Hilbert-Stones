using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject[] firstSet;
    public GameObject[] secondSet;
    
    private void Start()
    {
        Worker(firstSet, true);
        Worker(secondSet, false);
    }


    private void Worker(GameObject[] arrayToDo, bool setActive)
    {
        foreach (GameObject gameObject in arrayToDo)
        {
            gameObject.SetActive(setActive);
        }
    }

}
