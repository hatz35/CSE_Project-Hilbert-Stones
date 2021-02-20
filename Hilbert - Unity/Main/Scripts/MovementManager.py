import UnityEngine as ue
iamPlacing = False
xAllCells = gameObject.Cell(0, 0, "Normal", True, True, ue.Vector2D(0,0), "") #Manully Done in editor
selectedStone = ue.GameObject() //Empty
DM = ue.MonoBehaviour("DuelManager")
SD = ue.MonoBehaviour("StoneDatabase")

class MovementManager():
    def __init__(self, xAllCells, selectedStone, DM, SD, iamPlacing):
        self.xAllCells = xAllCells
        self.selectedStone = selectedStone
        self.DM = DM
        self.iamPlacing

    def Awake():
        SetTrig()
        SD = GameObject.FindGameObjectWithTag("Db").GetComponent("StoneDatabase")
        #Making Player B's Base Non-Walkable for A in the first turn only lol
        CantEnterEnemyBase()

    def SetTrig():
        #Setting Trigger on every Cell
        for a_cell in xAllCells:
            EventTrigger trigger = a_cell.GetComponen("EventTrigger")
            EventTrigger.Entry entry = EventTrigger.Entry()
            entry.eventID = EventTriggerType.PointerDown
            if entry.callback.AddListener == True:
                 OnPointerDownDelegate(a_cell)
            trigger.triggers.Add(entry)

    def OnPointerDownDelegate(a_cell):
        pointer = a_cell.transform.GetChild(0).gameObject
        if (pointer.activeInHierarchy):
            stonescript = selectedStone.GetComponent<Stone>()
            cellScript = a_cell.GetComponent("Cell")
            MakingOldPositionWalkable(stonescript)
            stonescript.xRow = cellScript.xRow
            stonescript.xCol = cellScript.xCol
            if (iamPlacing):
                stonescript.xIsPlaced = True

            UpdatePosition()
        }
        #Clicking here and there results in pointer cleaning
        #ps There is one panel-button cover most of the Scene which also call this function
        PointerVanish()


    def MakingOldPositionWalkable(ss): #Stone
        for a_cell in xAllCells:
            Cell cellScript = a_cell.GetComponent("Cell")
            if ((ss.xCol == cellScript.xCol) and (ss.xRow == cellScript.xRow)):
                cellScript.xIsWalkable = True
                cellScript.xCurrentStone = None
                break


    def PointerVanish():
        xAllPointers = GameObject.FindGameObjectsWithTag("Pointer")
        for pointer in xAllPointers:
            pointer.SetActive(False)
        iamPlacing = False

    def UpdatePosition():
        stonescript = selectedStone.GetComponent("Stone")
        for a_cell in xAllCells:
            cellScript = a_cell.GetComponent("Cell")
            if ((stonescript.xCol == cellScript.xCol) and (stonescript.xRow == cellScript.xRow)):
                selectedStone.transform.position = cellScript.transform.position
                cellScript.xIsWalkable = False
                cellScript.xCurrentStone = stonescript
                break

        selectedStone = None

        #Adding Turn Count
        if (DM.playerAturn):
            DM.numberOfTurns += 1

        #Sending Reminder to Add Score Turn is Done [BEFORE REVERSING THE TURN]
        DM.ReminderToAddScore()
        DM.ReminderToCheckUplift()

        #Interaction
        SD.Interact(stonescript)

        #Second Part Below

    def UpdatePosition2():
        #Reversing Turn
        DM.playerAturn = !DM.playerAturn
        #Resetting SB Bools
        SD.ResetBools()
        #Exiting Toolbox
        TB = this.gameObject.GetComponent("Toolbox")
        TB.DisplayNothing()
        #Making Enemy Base Non-Walkable
        CantEnterEnemyBase()

    def Placing(stone):
        iamPlacing = True
        stonescript = stone.GetComponent("Stone")
        if (!DM.playerAturn):
            for i in range(99, 95, -1):
                cellScript = xAllCells[i].GetComponent("Cell")
                if(shallPointerCome(cellScript)):
                    pointer = xAllCells[i].transform.GetChild(0).gameObject
                    pointer.SetActive(True)

        else if (DM.playerAturn):
            for i in range(0, 4):
                cellScript = xAllCells[i].GetComponent("Cell")
                if(shallPointerCome(cellScript)):
                    pointer = xAllCells[i].transform.GetChild(0).gameObject
                    pointer.SetActive(True)


    def SummMove(stone):
        #Assuring that when clicking already placed stone, previous pointers go away.
        PointerVanish()
        stonescript = stone.GetComponent("Stone")
        selectedStone = stone
        if (!stonescript.xIsPlaced):
            Placing(stone)
        else:
            #======= THE REAL DEAL =======
            #Showing Valid Move Options

            #Condition
            if (stuckInThrone(stonescript) and !stonescript.xCanMoveFromThrone):
                return

            #Checking Horizontal & Forward Movement
            if (stonescript.xMovementHorizontal > 0 and !stonescript.xCanMoveOnlyForward):
                canGoUpDown(stonescript, stonescript.xMovementHorizontal

            else if (stonescript.xMovementHorizontal > 0 && stonescript.xCanMoveOnlyForward):
                canGoUp(stonescript, stonescript.xMovementHorizontal)

            #Checking Vertical Movement
            if (stonescript.xMovementVertical > 0):
                canGoRightLeft(stonescript, stonescript.xMovementVertical)

            #Checking Diagonal Movement
            if (stonescript.xMovementDiagonal > 0):
                canGoDiagonal(stonescript, stonescript.xMovementDiagonal)

#region all_movement_types
    def canGoUpDown(ss, amount): #ss is stone
        for i in range(0, len(xAllCells)):
            cellScript = xAllCells[x].gameObject.GetComponent("Cell")
            if (IsWithin(cellScript.xRow, ss.xRow-amount, ss.xRow + amount) and ss.xCol == cellScript.xCol && shallPointerCome(cellScript)):
                GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject
                pointer.SetActive(True)


    def canGoRightLeft(ss, amount):
            for i in range(0, len(xAllCells)):
                cellScript = xAllCells[x].gameObject.GetComponent("Cell")
                if (IsWithin(cellScript.xCol, ss.xCol - amount, ss.xCol + amount) and ss.xRow == cellScript.xRow and shallPointerCome(cellScript))
                pointer = xAllCells[x].transform.GetChild(0).gameObject
                pointer.SetActive(True)

    def canGoUp(ss, amount):
            for i in range(0, len(xAllCells)):
                cellScript = xAllCells[x].gameObject.GetComponent("Cell")

                if (ss.xIsA):
                    if ((IsWithin(cellScript.xRow, ss.xRow, ss.xRow + amount)) and ss.xCol == cellScript.xCol and shallPointerCome(cellScript)):
                        GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject
                        pointer.SetActive(True)

                else if (!ss.xIsA):
                    if ((IsWithin(cellScript.xRow, ss.xRow - amount, ss.xRow)) and ss.xCol == cellScript.xCol and shallPointerCome(cellScript)):
                        GameObject pointer = xAllCells[x].transform.GetChild(0).gameObject
                        pointer.SetActive(True)


    def canGoDiagonal(ss, amount):
            diagonal_list =[]
            diagonal_list = diagonalChoices(ss.xRow, ss.xCol, amount)

            for i in range(0, len(xAllCells)):
                cellScript = xAllCells[x].gameObject.GetComponent("Cell")
                for ttuple in diagonal_list:
                        if (tuple.row == cellScript.xRow and tuple.col == cellScript.xCol and shallPointerCome(cellScript)):
                                pointer = xAllCells[x].transform.GetChild(0).gameObject
                                pointer.SetActive(True)
                                break


#endregion
#region all_condition_types
    def stuckInThrone(ss):
        if(IsWithin(ss.xRow, 7, 8) and IsWithin(ss.xCol, 7, 8)):
            return True
        else:
            return False

    def FindStonesNearby(ss, whatToDo):
        foundNothing = True
        IM = this.gameObject.GetComponent("InteractionManager")
        surroundingCells =
        [
            (ss.xRow+1, ss.xCol), (ss.xRow-1, ss.xCol),
            (ss.xRow, ss.xCol+1), (ss.xRow, ss.xCol-1), (ss.xRow+1, ss.xCol+1),
            (ss.xRow-1, ss.xCol+1), (ss.xRow+1, ss.xCol-1), (ss.xRow-1, ss.xCol-1)
        ]
        k = ss.xIsA
        amount = 0

        if (whatToDo == "Attack"):
            k = !k
            amount = ss.xAttackPower

        for i in range(0, len(xAllCells)):
            cS = xAllCells[x].gameObject.GetComponent("Cell")
            #shortening from cellScript to cS
            for sc in surroundingCells:
                if((cS.xRow, cS.xCol) == sc and cS.xCurrentStone != null and k == cS.xCurrentStone.xIsA):
                        if (whatToDo == "Merge" and cS.xCurrentStone.xName != ss.xName and cS.xCurrentStone.xIsA == ss.xIsA):
                                continue
                        else:
                                IM.AddOption(whatToDo, cS.xCurrentStone, ss, amount)
                                foundNothing = False
                                break

        if (foundNothing):
            SD.interactingNow = False

        else:
            if(whatToDo == "Attack"):
                SD.attackPossible = True

            else if (whatToDo == "Merge"):
                SD.mergePossible = True

            else if (whatToDo == "Explode"):
                SD.explodePossible = True


    def CantEnterEnemyBase():
        if (DM.playerAturn):
            for i in range(0, len(xAllCells)):
                    cellScript = xAllCells[x].gameObject.GetComponent("Cell")
                    if(cellScript.xRow == 13 or cellScript.xRow == 14):
                        cellScript.xIsWalkable = false

        else:
            for i in range(0, len(xAllCells)):
                    cellScript = xAllCells[x].gameObject.GetComponent("Cell")
                    if (cellScript.xRow == 1 or cellScript.xRow == 2 and cellScript.xCurrentStone == None):
                            cellScript.xIsWalkable = true

        else if (!DM.playerAturn):
            for i in range(0, len(xAllCells)):
                    cellScript = xAllCells[x].gameObject.GetComponent("Cell")
                    if (cellScript.xRow == 13 or cellScript.xRow == 14 and cellScript.xCurrentStone == None):
                            cellScript.xIsWalkable = true

            for i in range(0, len(xAllCells)):
                    cellScript = xAllCells[x].gameObject.GetComponent("Cell")
                    if (cellScript.xRow == 1 or cellScript.xRow == 2):
                        cellScript.xIsWalkable = false

    #endregion

    #region CalculationFunctions
    #this doesn't really help when b>a for some reason


    def shallPointerCome(cell):
        if(cell.xIsWalkable && cell.xCurrentStone == None):
            return True

        else:
            return False


    def IsWithin(value, a, b):
        if (b > a):
            return value >= a and value <= b

        else if (a > b):
            return value <= a and value >= b

        else:
            return False

    def diagonalChoices(row, col, amount):
        tupleList = []
        for i in range(0, len(amount))
            tupleList.Add((row + i, col + i))
            tupleList.Add((row + i, col - i))
            tupleList.Add((row - i, col + i))
            tupleList.Add((row - i, col - i))

        return tupleList


    def clearCell(row, col):
        for i in range(0, len(xAllCells)):
            cellScript = cellObject.GetComponent("Cell")
            if(cellScript.xRow == row && cellScript.xCol == col):
                cellScript.xIsWalkable = True
                cellScript.xCurrentStone = None

#endregion
#AFTER THIS MAKE ALL OTHER MOVEMENT FUNCTIONS AND SPECIAL ABILITY FUNCTIONS
#ADD SCORE OPTIONS
