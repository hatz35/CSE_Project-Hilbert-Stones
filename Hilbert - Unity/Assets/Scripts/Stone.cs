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
            xTypeCell = "Guardian";
            xHealth = 50;
            xMovementHorizontal = 2;
            xMovementVertical = 3;
        }

        else if (xName == "Aquamarine")
        {
            xTypeCell = "Luxury";
            xHealth = 5;
            xMovementHorizontal = 2;
            xMovementVertical = 2;
            xScorePerTurn = 30;
        }

        else if (xName == "Jadeite")
        {
            xTypeCell = "Luxury";
            xMovementHorizontal = 2;
            xMovementVertical = 1;
            xHealth = 15;
            xScorePerTurn = 20;
            xMergeMultiplier = 3;
            xSimpleMergePossible = true;

        }

        else if (xName == "Opal")
        {
            xTypeCell = "Luxury";
            xMovementHorizontal = 1;
            xCanMoveFromThrone = false;
            xCanMoveOnlyForward = true;
            xScorePerTurn = 10;
            xScoreExponentialGrowth = true;

        }

        else if (xName == "Adrovay")
        {
            xTypeCell = "Punisher";
            xHealth = 25;
            xMovementHorizontal = 2;
            xMovementVertical = 2;
            xMovementDiagonal = 2;
            xAttackPower = 5;
            xThroneExplosion = true;
            xThroneExplosionSteal = 50;
        }

        else if(xName == "Amethyst")
        {
            xTypeCell = "Punisher";
            xMovementDiagonal = 1;
            xAttackPower = 100;
            xHealth = 5;
        }

    }



}
