using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DuelManager : MonoBehaviour
{
    public int winningAmount = 300;
    public int numberOfTurns = 0;
    public bool playerAturn = true;
    public GameObject blockerA;
    public GameObject blockerB;
    public GameObject turnA;
    public GameObject turnB;

    public int xScoreA = 0;
    public int xScoreB = 0;
    public TextMeshProUGUI scoreA;
    public TextMeshProUGUI scoreB;


    [Space(20)]
    public StoneManager SM1;
    public StoneManager SM2;

    private void Update()
    {
        if (playerAturn)
        {
            blockerB.SetActive(true);
            blockerA.SetActive(false);
            turnA.SetActive(true);
            turnB.SetActive(false);
        }
        else
        {
            blockerA.SetActive(true);
            blockerB.SetActive(false);
            turnA.SetActive(false);
            turnB.SetActive(true);
        }

        scoreA.text = xScoreA.ToString();
        scoreB.text = xScoreB.ToString();

        checkEnd();

    }

    private void checkEnd()
    {
        General GEN = this.gameObject.GetComponent<General>();
        if (xScoreA >= winningAmount)
        {
            GEN.DeclareWinner(true, xScoreA - xScoreB);

        }

        else if (xScoreB >= winningAmount)
        {
            GEN.DeclareWinner(false, xScoreB - xScoreA);
        }

    }


    public void ReminderToAddScore()
    {
        SM1.WhichStoneInThrone();
        SM2.WhichStoneInThrone();
    }

    public void ReminderToCheckUplift()
    {
        SM1.WhichStoneInUplift();
        SM2.WhichStoneInUplift();
    }
    public void AddScore(int amount)
    {
        if (playerAturn)
        {
            xScoreA += amount;

        }

        else if (!playerAturn)
        {
            xScoreB += amount;

        }
    }

}


