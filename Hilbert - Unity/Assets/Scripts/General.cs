using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class General : MonoBehaviour
{
    public GameObject[] startingObjects;
    public GameObject[] nonStartingObjects;
    public GameObject[] endingObjects;
    public TextMeshProUGUI resultText;
    public GameObject player1InputField;
    public GameObject player2InputField;
    public TextMeshProUGUI player1Name;
    public TextMeshProUGUI player2Name;
    public string Name1;
    public string Name2;


    [Space(20)]
    public GameObject sprites;
    private bool wereSpritesShut = false;
    public void Start()
    {

        OpenerOrCloser(startingObjects, true);
        OpenerOrCloser(endingObjects, false);
        OpenerOrCloser(nonStartingObjects, false);
    }

    public void Starting()
    {
        Name1 = player1InputField.GetComponent<TMP_InputField>().text;
        Name2 = player2InputField.GetComponent<TMP_InputField>().text;
        if (string.IsNullOrEmpty(Name1))
        {
            Name1 = "Player 1";
        }


        if (string.IsNullOrEmpty(Name2))
        {
            Name2 = "Player 2";
        }

        player1Name.text = Name1;
        player2Name.text = Name2;

        OpenerOrCloser(startingObjects, false);
        OpenerOrCloser(endingObjects, false);
        OpenerOrCloser(nonStartingObjects, true);

    }


    private void OpenerOrCloser(GameObject[] array, bool setActive)
    {
        foreach (GameObject go in array)
        {
            go.SetActive(setActive);
        }

    }
    public void PauseGame()
    {
        if (sprites.activeInHierarchy)
        {
            sprites.SetActive(false);
            wereSpritesShut = true;
        }
        Time.timeScale = 0;

    }
    public void ResumeGame()
    {
        if (wereSpritesShut == true)
        {
            sprites.SetActive(true);
        }
        Time.timeScale = 1;

        wereSpritesShut = false;

    }

    public void DeclareWinner(bool player1Won, int difference)
    {
        OpenerOrCloser(startingObjects, false);
        OpenerOrCloser(nonStartingObjects, false);
        OpenerOrCloser(endingObjects, true);

        string winnerName;
        if (player1Won)
        {
            winnerName = Name1;
        }
        else
        {
            winnerName = Name2;
        }

        resultText.text = "Winner - " + winnerName + "\nVictory by " + difference.ToString() + " Points";

    }
}
