using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class LearnManager : MonoBehaviour
{
    [System.Serializable]
    public class StoneData
    {
        public string xName;
        [Space(10)]
        [TextArea(6, 10)]
        public string xLore;
        [Space(10)]
        [TextArea(10,40)]
        public string xGuide;
        [Space(10)]
        public Sprite xStoneImage;
    }


    public StoneData[] stonedb;
    private static List<StoneData> stonelib;
    [Space(50)]

    public TextMeshProUGUI LoreSlot;
    public TextMeshProUGUI GuideSlot;
    public TextMeshProUGUI indexSlot;
    public TextMeshProUGUI titleSlot;
    public Image StoneImageSlot;
    private int currentIndex = 1;
    [Space(10)]

    public GameObject backButton;
    public GameObject nextButton;
    public Button StoneDataButton;
    public void Start()
    {
        stonelib = stonedb.ToList<StoneData>();

        StoneDataButton.interactable = false;

    }
    public void Update()
    {
        DisplayStone();
        CheckEnd();
    }

    private void CheckEnd()
    {
        if (currentIndex == 1)
        {
            backButton.SetActive(false);

        }
        else
        {
            backButton.SetActive(true);
        }

        if(currentIndex == stonedb.Length)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }

    }
    private void DisplayStone()
    {
        indexSlot.text = currentIndex.ToString();
        titleSlot.text = stonelib[currentIndex - 1].xName;
        LoreSlot.text = stonelib[currentIndex - 1].xLore;
        GuideSlot.text = stonelib[currentIndex - 1].xGuide;
        StoneImageSlot.sprite = stonelib[currentIndex - 1].xStoneImage;
    }

    public void AddIndex()
    {
        currentIndex += 1;
    }

    public void SubIndex()
    {
        currentIndex -= 1;
    }
}
