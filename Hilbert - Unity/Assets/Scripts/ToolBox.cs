using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToolBox : MonoBehaviour
{
    public GameObject toolbox;
    public TextMeshProUGUI xStoneName;
    public TextMeshProUGUI xStoneData;
    public Image xStoneImage;
    private General GEN;
    public void DisplayStoneData(GameObject stoneObject)
    {
        Stone stone = stoneObject.GetComponent<Stone>();
        toolbox.SetActive(true);
        string xNamePlayer;
        GEN = this.gameObject.GetComponent<General>();
        if (stone.xIsA)
        {
            xNamePlayer = GEN.Name1;

        }

        else 
        {
            xNamePlayer = GEN.Name2;

        }
        string xMerger;
        if(xNamePlayer.Substring(xNamePlayer.Length - 1) == "s")
        {
            xMerger = "' ";
        }
        else
        {
            xMerger = "'s ";
        }

        xStoneName.text = xNamePlayer + xMerger + stone.xName;
        xStoneImage.sprite = stone.xStoneImage;
        string data = "";
        data += stone.xTypeCell + " Type\n";
        data += "Current Health - " + stone.xHealth.ToString() + "\n";
        data += "Score Per Turn - " + stone.xScorePerTurn.ToString() + "\n";
        data += "Attack Power - " + stone.xAttackPower.ToString() + "\n";
        if (stone.xBoosted)
        {
            data += "Boosted!\n";
        }
        xStoneData.text = data;

    }

    public void DisplayNothing()
    {
        toolbox.SetActive(false);

    }

}
