using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public GameObject[] xButtons;
    private int xIndex = 0;
    DuelManager DM;
    MovementManager MM;
    StoneDatabase SD;



    private void Update()
    {
        if (xIndex > 0)
        {
            //spawn panel
        }
    }

    private void Start()
    {
        DM = this.gameObject.GetComponent<DuelManager>();
        MM = this.gameObject.GetComponent<MovementManager>();
        SD = GameObject.FindGameObjectWithTag("Db").GetComponent<StoneDatabase>();

        Reset();
    }
    public void AddOption(string whatToDo, Stone targetStone, Stone currentStone, int amountIfAny)
    {

        AddNow(whatToDo, targetStone, currentStone, amountIfAny);
        AddDoNothingOption();

    }

    private void AddNow(string whatToDo, Stone targetStone, Stone currentStone, int amountIfAny)
    {
        GameObject newBut = xButtons[xIndex];
        newBut.SetActive(true);
        TextMeshProUGUI commandText = newBut.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        commandText.text = whatToDo;
        


        if(targetStone != null)
        {
            Image targetStoneImage = newBut.transform.GetChild(1).gameObject.GetComponent<Image>();
            targetStoneImage.sprite = targetStone.xStoneImage;
        }

        else if(targetStone == null && currentStone != null)
        {
            Image targetStoneImage = newBut.transform.GetChild(1).gameObject.GetComponent<Image>();
            targetStoneImage.sprite = currentStone.xStoneImage;
        }

        else {
            Image targetStoneImage = newBut.transform.GetChild(1).gameObject.GetComponent<Image>();
            targetStoneImage.gameObject.SetActive(false);

        }


        if(newBut.GetComponent<Button>() != null)
        {
            Button newButButton = newBut.GetComponent<Button>();
            newButButton.onClick.AddListener(delegate { TaskOnClick(whatToDo, amountIfAny, targetStone, currentStone); });
        }
        else
        {
            newBut.AddComponent<Button>();
            Button newButButton = newBut.GetComponent<Button>();
            newButButton.onClick.AddListener(delegate { TaskOnClick(whatToDo, amountIfAny, targetStone, currentStone); });

        }
        xIndex += 1;

    }

    private void AddDoNothingOption()
    {
        if(xIndex == 1)
        {
            AddNow("Pass", null, null, 0);

        }
        else
        {
            return;
        }
    }

    private void TaskOnClick(string whatToDo, int amountIfAny, Stone targetStone, Stone currentStone)
    {
        if(whatToDo == "Attack")
        {
            targetStone.xHealth -= amountIfAny;
            checkIfAlive(targetStone);
            checkIfAlive(currentStone);
        }
        else if (whatToDo == "Explode")
        {
            currentStone.xHealth -= 1000;
            StealScore(currentStone, amountIfAny);
            checkIfAlive(currentStone);
        }

        else if (whatToDo == "Merge")
        {
            currentStone.xHealth = (currentStone.xHealth + targetStone.xHealth) * currentStone.xMergeMultiplier;
            targetStone.xHealth -= 1000;
            checkIfAlive(targetStone);
        }

        Reset();
        ContinueGame();

    }


    private void StealScore(Stone stone, int amount)
    {
        if (stone.xIsA)
        {
            DM.xScoreA += amount;
            DM.xScoreB -= amount;

        }

        else
        {
            DM.xScoreB += amount;
            DM.xScoreA -= amount;

        }
    }

    private void checkIfAlive(Stone stone)
    {
        if (stone.xHealth <= 0)
        {
            stone.gameObject.SetActive(false);
            MM.clearCell(stone.xRow, stone.xCol);
            stone.xRow = 0;
            stone.xCol = 0;
        }

    }

    private void Reset()
    {
        foreach(GameObject but in xButtons)
        {
            but.SetActive(false);
            Button newButButton = but.GetComponent<Button>();
            Destroy(newButButton);
        }

        xIndex = 0;
        
    }

    public void ContinueGame()
    {
        MM.UpdatePosition2();
    }
}
