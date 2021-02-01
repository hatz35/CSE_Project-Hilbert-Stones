using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDatabase : MonoBehaviour
{

    public GameObject[] stonedb;
    public StoneManager player1SM;
    public StoneManager player2SM;

    public bool interactingNow = false;
    InteractionManager IM;
    public bool attackPossible = false;
    public bool mergePossible = false;
    public bool explodePossible = false;


    private void Awake()
    {
        IM = GameObject.FindGameObjectWithTag("Manager").GetComponent<InteractionManager>();

    }

    private GameObject findStone(string name)
    {
        foreach(GameObject stone in stonedb)
        {
            Stone ss = stone.GetComponent<Stone>();
            if(ss.xName == name)
            {
                return stone;
            }
        }
        return null;
    }

    public void BoostStone(Stone stone, bool playerAturn)
    {
        if (!stone.xBoosted)
        {
            if (stone.xName == "Iron")
            {
                stone.xHealth = 30;
            }

            else if (stone.xName == "Silver")
            {
                stone.xMovementDiagonal = 3;
            }

            else if (stone.xName == "Copper")
            {
                if (playerAturn)
                {
                    player1SM.AddingStone(findStone("Copper"));

                }

                else
                {
                    player2SM.AddingStone(findStone("Copper"));
                }
            }

            else if (stone.xName == "Platinum")
            {
                stone.xScorePerTurn = 50;

            }
        }

        stone.xBoosted = true;
    }


    public void Interact(Stone stone)
    {
        MovementManager MM = GameObject.FindGameObjectWithTag("Manager").GetComponent<MovementManager>();
        if (stone.xAttackPower > 0)
        {
            interactingNow = true;
            MM.FindStonesNearby(stone, "Attack");
        }

        if (stone.xSimpleMergePossible)
        {
            interactingNow = true;
            MM.FindStonesNearby(stone, "Merge");
        }

        if (stone.xThroneExplosion && MM.stuckInThrone(stone))
        {
            interactingNow = true;
            IM.AddOption("Explode", null, stone, stone.xThroneExplosionSteal);
        }

        bool huh = !interactingNow && !attackPossible && !mergePossible && !explodePossible;
        if (huh)
        {
            MM.UpdatePosition2();
        }

        else if (!huh)
        {
            smartBlocker(player1SM.stones, true);
            smartBlocker(player2SM.stones, true);
            //Can Use Stone Manager's Blocker Reverser? And you can even shorten that like i did here
        }

    }

    private void smartBlocker(GameObject[] stoneObjects, bool shallBlock)
    {
        foreach (GameObject stone in stoneObjects)
        {
            Stone stoneScript = stone.GetComponent<Stone>();
            stoneScript.xBlocked = shallBlock;
        }

    }

    public void ResetBools()
    {
        attackPossible = false;
        mergePossible = false;
        explodePossible = false;
        interactingNow = false;
        smartBlocker(player1SM.stones, false);
        smartBlocker(player2SM.stones, false);
    }


}
