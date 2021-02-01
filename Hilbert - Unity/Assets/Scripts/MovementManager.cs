using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementManager : MonoBehaviour
{

    private bool iamPlacing = false;

    public GameObject[] xAllCells;
    private GameObject selectedStone;
    public DuelManager DM;
    public StoneDatabase SD;

    private void Awake()
    {
        SetTrig();
        SD = GameObject.FindGameObjectWithTag("Db").GetComponent<StoneDatabase>();

        //Making Player B's Base Non-Walkable for A in the first turn only lol
        CantEnterEnemyBase();
    }
    private void SetTrig()
    {   
        //Setting Trigger on every Cell 
        foreach (GameObject a_cell in xAllCells)
        {
            EventTrigger trigger = a_cell.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data, a_cell); });
            trigger.triggers.Add(entry);
        }
    }
    public void OnPointerDownDelegate(PointerEventData data, GameObject a_cell)
    {
        GameObject pointer = a_cell.transform.GetChild(0).gameObject;
        if (pointer.activeInHierarchy)
        {
            Stone stonescript = selectedStone.GetComponent<Stone>();
            Cell cellScript = a_cell.GetComponent<Cell>();
            MakingOldPositionWalkable(stonescript);
            stonescript.xRow = cellScript.xRow;
            stonescript.xCol = cellScript.xCol;

            if (iamPlacing)
            {
                stonescript.xIsPlaced = true;
            } 

            UpdatePosition();
        }
        //Clicking here and there results in pointer cleaning 
        //ps There is one panel-button cover most of the Scene which also call this function
        PointerVanish();
    }
    private void MakingOldPositionWalkable(Stone ss)
    {
        foreach (GameObject a_cell in xAllCells)
        {
            Cell cellScript = a_cell.GetComponent<Cell>();

            if ((ss.xCol == cellScript.xCol) && (ss.xRow == cellScript.xRow))
            {
                cellScript.xIsWalkable = true;
                cellScript.xCurrentStone = null;
                break;
            }
        }

    }
    public void PointerVanish()
    {


        GameObject[] xAllPointers = GameObject.FindGameObjectsWithTag("Pointer");
        foreach(GameObject pointer in xAllPointers)
        {
            pointer.SetActive(false);
        }
        iamPlacing = false;
    }
    private void UpdatePosition()
    {
        Stone stonescript = selectedStone.GetComponent<Stone>();

        foreach (GameObject a_cell in xAllCells)
        {
            Cell cellScript = a_cell.GetComponent<Cell>();
 
            if ((stonescript.xCol == cellScript.xCol) && (stonescript.xRow == cellScript.xRow))
            {
                selectedStone.transform.position = cellScript.transform.position;
                cellScript.xIsWalkable = false;
                cellScript.xCurrentStone = stonescript;

                break;
            }
        }
        selectedStone = null;

        //Adding Turn Count
        if (DM.playerAturn)
        {
            DM.numberOfTurns += 1;

        }

        //Sending Reminder to Add Score Turn is Done [BEFORE REVERSING THE TURN]
        DM.ReminderToAddScore();
        DM.ReminderToCheckUplift();

        //Interaction
        SD.Interact(stonescript);
        
        //Second Part Below


    }

    public void UpdatePosition2()
    {
        //Reversing Turn
        DM.playerAturn = !DM.playerAturn;

        //Resetting SB Bools
        SD.ResetBools();

        //Exiting Toolbox
        ToolBox TB = this.gameObject.GetComponent<ToolBox>();
        TB.DisplayNothing();

        //Making Enemy Base Non-Walkable
        CantEnterEnemyBase();

    }
    private void Placing(GameObject stone)
    {
        iamPlacing = true;
        Stone stonescript = stone.GetComponent<Stone>();
        if (!DM.playerAturn)
        {
            for(int i = 99; i > 95; i--)
            {
                Cell cellScript = xAllCells[i].GetComponent<Cell>();
                if(shallPointerCome(cellScript))
                {
                    GameObject pointer = xAllCells[i].transform.GetChild(0).gameObject;
                    pointer.SetActive(true);    

                }   
            }
        }
        else if (DM.playerAturn)
        {
            for (int i = 0; i < 4; i++)
            {

                Cell cellScript = xAllCells[i].GetComponent<Cell>();
                if (shallPointerCome(cellScript))
                {
                    GameObject pointer = xAllCells[i].transform.GetChild(0).gameObject;
                    pointer.SetActive(true);

                }
            }
        }


    }
    public void SummonMove(GameObject stone)
    {
        //Assuring that when clicking already placed stone, previous pointers go away.
        PointerVanish();
        Stone stonescript = stone.GetComponent<Stone>();
        selectedStone = stone;
        if (!stonescript.xIsPlaced)
        {
            Placing(stone);
        }

        else
        {
            //======= THE REAL DEAL =======
            //Showing Valid Move Options 


            //Condition
            if (stuckInThrone(stonescript) && !stonescript.xCanMoveFromThrone)
            {
                return;
            }

            //Checking Horizontal & Forward Movement 
            if (stonescript.xMovementHorizontal > 0 && !stonescript.xCanMoveOnlyForward)
            {
                canGoUpDown(stonescript, stonescript.xMovementHorizontal);
            }
            else if (stonescript.xMovementHorizontal > 0 && stonescript.xCanMoveOnlyForward)
            {
                canGoUp(stonescript, stonescript.xMovementHorizontal);
            }

            //Checking Vertical Movement
            if (stonescript.xMovementVertical > 0)
            {
                canGoRightLeft(stonescript, stonescript.xMovementVertical);
            }

            //Checking Diagonal Movement
            if (stonescript.xMovementDiagonal > 0)
            {
                canGoDiagonal(stonescript, stonescript.xMovementDiagonal);
            }

        }


    }

#region all_movement_types
    private void canGoUpDown(Stone ss, int amount)
    {
        for (int x = 0; x < xAllCells.Length; x++)
        {
            Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();

            if (IsWithin(cellScript.xRow, ss.xRow-amount, ss.xRow + amount) && ss.xCol == cellScript.xCol && shallPointerCome(cellScript))
            {
                GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject;
                pointer.SetActive(true);
            }
        }
    }

    private void canGoRightLeft(Stone ss, int amount)
    {
        for (int x = 0; x < xAllCells.Length; x++)
        {
            Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();

            if (IsWithin(cellScript.xCol, ss.xCol - amount, ss.xCol + amount) && ss.xRow == cellScript.xRow && shallPointerCome(cellScript))
            {
                GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject;
                pointer.SetActive(true);
            }
        }
    }
    private void canGoUp(Stone ss, int amount)
    {
        for (int x = 0; x < xAllCells.Length; x++)
        {
            Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();

            if (ss.xIsA)
            {
                if ((IsWithin(cellScript.xRow, ss.xRow, ss.xRow + amount)) && ss.xCol == cellScript.xCol && shallPointerCome(cellScript))
                {
                    GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject;
                    pointer.SetActive(true);
                }
            }

            else if (!ss.xIsA)
            {
                if ((IsWithin(cellScript.xRow, ss.xRow - amount, ss.xRow)) && ss.xCol == cellScript.xCol && shallPointerCome(cellScript))
                {
                    GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject;
                    pointer.SetActive(true);
                }
            }

        }
    }


    private void canGoDiagonal(Stone ss, int amount)
    {
        var diagonal_list = new List<(int row, int col)>() { };
        diagonal_list = diagonalChoices(ss.xRow, ss.xCol, amount);

        for (int x = 0; x < xAllCells.Length; x++)
        {
            Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();
            foreach (var tuple in diagonal_list)
            {
                if (tuple.row == cellScript.xRow && tuple.col == cellScript.xCol && shallPointerCome(cellScript))
                {
                    GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject;
                    pointer.SetActive(true);
                    break;
                }
            }

        }
    }

#endregion

#region all_condition_types
    public bool stuckInThrone(Stone ss)
    {
        if(IsWithin(ss.xRow, 7, 8) && IsWithin(ss.xCol, 7, 8))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void FindStonesNearby(Stone ss, string whatToDo)
    {
        bool foundNothing = true;
        InteractionManager IM = this.gameObject.GetComponent<InteractionManager>();
        var surroundingCells = new List<(int Row, int Col)>
        {
            (ss.xRow+1, ss.xCol),
            (ss.xRow-1, ss.xCol),
            (ss.xRow, ss.xCol+1),
            (ss.xRow, ss.xCol-1),
            (ss.xRow+1, ss.xCol+1),
            (ss.xRow-1, ss.xCol+1),
            (ss.xRow+1, ss.xCol-1),
            (ss.xRow-1, ss.xCol-1),
        };

        bool k = ss.xIsA;
        int amount = 0;

        if (whatToDo == "Attack")
        {
            k = !k;
            amount = ss.xAttackPower;
        }

        for (int x = 0; x < xAllCells.Length; x++)
        {
            Cell cS = xAllCells[x].gameObject.GetComponent<Cell>();
            //shortening from cellScript to cS

            foreach(var sc in surroundingCells)
            {
                if((cS.xRow, cS.xCol) == sc && cS.xCurrentStone != null && k == cS.xCurrentStone.xIsA)
                {
                    if (whatToDo == "Merge" && cS.xCurrentStone.xName != ss.xName && cS.xCurrentStone.xIsA == ss.xIsA)
                    {
                        continue;
                    }
                    else
                    {
                        IM.AddOption(whatToDo, cS.xCurrentStone, ss, amount);
                        foundNothing = false;
                        break;
                    }

                }
            }
        }

        if (foundNothing)
        {
            SD.interactingNow = false;
        }
        else
        {
            if(whatToDo == "Attack")
            {
                SD.attackPossible = true;
            }
            else if (whatToDo == "Merge")
            {
                SD.mergePossible = true;
            }
            else if (whatToDo == "Explode")
            {
                SD.explodePossible = true;
            }
        }

    }

    public void CantEnterEnemyBase()
    {
        if (DM.playerAturn)
        {
            for (int x = 0; x < xAllCells.Length; x++)
            {
                Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();
                if(cellScript.xRow == 13 || cellScript.xRow == 14)
                {
                    cellScript.xIsWalkable = false;
                }
            }

            for (int x = 0; x < xAllCells.Length; x++)
            {
                Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();
                if (cellScript.xRow == 1 || cellScript.xRow == 2 && cellScript.xCurrentStone == null)
                {
                    cellScript.xIsWalkable = true;
                }
            }

        }


        else if (!DM.playerAturn)
        {
            for (int x = 0; x < xAllCells.Length; x++)
            {
                Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();
                if (cellScript.xRow == 13 || cellScript.xRow == 14 && cellScript.xCurrentStone == null)
                {
                    cellScript.xIsWalkable = true;
                }
            }

            for (int x = 0; x < xAllCells.Length; x++)
            {
                Cell cellScript = xAllCells[x].gameObject.GetComponent<Cell>();
                if (cellScript.xRow == 1 || cellScript.xRow == 2)
                {
                    cellScript.xIsWalkable = false;
                }
            }

        }

    }

    #endregion

    #region CalculationFunctions
    //this doesn't really help when b>a for some reason


    private static bool shallPointerCome(Cell cell)
    {
        if(cell.xIsWalkable && cell.xCurrentStone == null)
        {
            return true;

        }

        else
        {
            return false;
        }
    }

    public static bool IsWithin(int value, int a, int b)
    {
        if (b > a)
        {
            return value >= a && value <= b;

        }

        else if (a > b)
        {
            return value <= a && value >= b;
        }

        else
        {
            return false;
        }
    }
    public static List<(int, int)> diagonalChoices(int row, int col, int amount)
    {
        var tupleList = new List<(int row, int col)>() { };
        
        for(int i = 1; i <= amount; i++)
        {
            tupleList.Add((row + i, col + i));
            tupleList.Add((row + i, col - i));
            tupleList.Add((row - i, col + i));
            tupleList.Add((row - i, col - i));
        }

        return tupleList;

    }

    public void clearCell(int row, int col)
    {
        foreach(GameObject cellObject in xAllCells)
        {
            Cell cellScript = cellObject.GetComponent<Cell>();
            if(cellScript.xRow == row && cellScript.xCol == col)
            {
                cellScript.xIsWalkable = true;
                cellScript.xCurrentStone = null;

            }
        }

    }
#endregion
}

// AFTER THIS MAKE ALL OTHER MOVEMENT FUNCTIONS AND SPECIAL ABILITY FUNCTIONS 
// ADD SCORE OPTIONS   