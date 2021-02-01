using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public int xRow;
    public int xCol;
    public bool xIsA;
    public bool xIsAlive = true;
    public bool xIsPlaced = false;
    public bool xIsActive = true;
    public Sprite xStoneImage;
    public bool xBoosted = false;
    public bool xBlocked = false;

    [Space(20)]
    public string xName;
    public string xTypeCell = "Standard";
    public int xHealth = 1;
    public int xAttackPower = 0;
    public int xScorePerTurn = 0;
    public int xMovementHorizontal = 0;
    public int xMovementVertical = 0;
    public int xMovementDiagonal = 0;
    
    [Space(20)]
    public bool xCanMoveOnlyForward = false;
    public bool xCanMoveFromThrone = true;
    public bool xScoreExponentialGrowth = false;
    public bool xSimpleMergePossible = false;
    public int xMergeMultiplier = 0;
    public bool xThroneExplosion = false;
    public int xThroneExplosionSteal = 0;

    [Space(20)]
    public int xHowLongInThrone = 0;
    public int xNewScorePerTurn;

    void Awake()
    {
        if (xName == "Iron")
        {
            xTypeCell = "Standard";
            xHealth = 30;
            xMovementHorizontal = 1;
            xMovementVertical = 1;
        }

        else if (xName == "Silver")
        {
            xTypeCell = "Standard";
            xHealth = 10;
            xAttackPower = 4;
            xMovementDiagonal = 1;
        }

        else if (xName == "Gold")
        {
            xTypeCell = "Standard";
            xHealth = 6;
            xScorePerTurn = 10;
            xScoreExponentialGrowth = true;
            xMovementHorizontal = 1;
            xCanMoveOnlyForward = true;
            xCanMoveFromThrone = false;
        }

        else if (xName == "Copper")
        {
            xTypeCell = "Standard";
            xHealth = 5;
            xMovementHorizontal = 2;
            xMovementVertical = 2;
            xSimpleMergePossible = true;
            xMergeMultiplier = 3;
        }

        else if (xName == "Platinum")
        {
            xTypeCell = "Standard";
            xHealth = 1;
            xMovementHorizontal = 3;
            xMovementVertical = 3;
            xThroneExplosion = true;
            xThroneExplosionSteal = 50;
        }

        else if(xName == "Bakt")
        {
            xTypeCell = "Mythical";
        }

    }



}
