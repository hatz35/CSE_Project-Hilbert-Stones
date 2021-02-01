using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StoneManager : MonoBehaviour
{
    public bool isA;
    public DuelManager DM;
    private StoneDatabase SD; //StoneDatabase
    public GameObject[] stones;
    public GameObject[] boxes;
    public MovementManager MM;

    private void Awake()
    {
        foreach (GameObject stone in stones)
        {
            Stone stonescript = stone.GetComponent<Stone>();
            stonescript.xIsA = isA;
        }
        WhichStone();
        ThrowInInventory();

        SD = GameObject.FindGameObjectWithTag("Db").GetComponent<StoneDatabase>();
    }

    private void Update()
    {
        BlockerAndReverse();
    }

    public void WhichStoneInUplift()
    {
        //is there a stone in Uplift?
        foreach (GameObject stone in stones)
        {
            Stone stonescript = stone.GetComponent<Stone>();
            if (IsWithin(stonescript.xCol, 13, 14) || IsWithin(stonescript.xCol, 1, 2))
            {
                print("There is one stone there -> " + stonescript.xName);
                SD.BoostStone(stonescript, DM.playerAturn);
            }
        }

    }

    public void WhichStoneInThrone()
    {
        //is there a stone in Throne?
        foreach (GameObject stone in stones)
        {
            Stone stonescript = stone.GetComponent<Stone>();
            if (IsWithin(stonescript.xRow, 7, 8) && IsWithin(stonescript.xCol, 7, 8))
            {
                //print("There is one stone there -> " + stonescript.xName);  
                //Nice time to add Streak too 
                AddStreak(stonescript);
            }

            else
            {
                //If you ain't in the throne
                stonescript.xHowLongInThrone = 0;
            }
        }

    }
    public static bool IsWithin(int value, int a, int b)
    {
        if (b > a)
        {
            return value >= a && value <= b;

        }

        else
        {
            return false;
        }
    }

        private void AddStreak(Stone ss)
    {
        //Nice time to add streak 

        if (DM.playerAturn == ss.xIsA) //On A's turn A'stone will increase its streak -> Same for B
        {
            ss.xHowLongInThrone += 1;

            if (ss.xScoreExponentialGrowth)
            {
                ss.xNewScorePerTurn = ss.xScorePerTurn * ss.xHowLongInThrone;
                DM.AddScore(ss.xNewScorePerTurn);

            }

            DM.AddScore(ss.xScorePerTurn);


        }

    }

    private void BlockerAndReverse()
    {
        if (isA && DM.playerAturn)
        {
            reverse_blocker(stones);
        }

        else if (isA && DM.playerAturn == false)
        {
            blocker(stones);
        }

        if (isA == false && DM.playerAturn)
        {
            blocker(stones);
        }

        else if(isA == false & DM.playerAturn == false)
        {
            reverse_blocker(stones);
        }

    }

    private void WhichStone()
    {
        foreach (GameObject stone in stones)
        {
            DressStone(stone);

        }

    }

    private void ThrowInInventory()
    {
        int sn = 0;
        foreach (GameObject box in boxes)
        {
            try
            {
                stones[sn].transform.position = box.transform.position;
            }
            catch (Exception e)
            {
                print(e);
            }
            sn += 1;
        }
    }

    private void blocker(GameObject[] allStones)
    {
        foreach (GameObject stone in allStones)
        {
            BoxCollider2D BC = stone.GetComponent<BoxCollider2D>();
            BC.enabled = false;

        }
    }

    private void reverse_blocker(GameObject[] allStones)
    {
        foreach (GameObject stone in allStones)
        {
            BoxCollider2D BC = stone.GetComponent<BoxCollider2D>();
            BC.enabled = true;
        }
    }

    public void AddingStone(GameObject StoneToAdd)
    {
        foreach(GameObject box in boxes)
        {
            bool isEmpty = true;

            foreach (GameObject stone in stones)
            {
                if(stone.transform.position == box.transform.position)
                {
                    isEmpty = false;
                    break;
                }
                else
                {
                    continue;
                }
            }

            if(isEmpty == true)
            {
                var newStoneAdded = Instantiate(StoneToAdd);
                DressStone(StoneToAdd);
                newStoneAdded.transform.position = box.transform.position;
                newStoneAdded.transform.parent = this.gameObject.transform;
            }
        }
    }

    private void DressStone(GameObject stone)
    {
        Stone stonescript = stone.GetComponent<Stone>();
        SpriteRenderer sr = stone.GetComponent<SpriteRenderer>();
        sr.sprite = stonescript.xStoneImage;
    }


}
