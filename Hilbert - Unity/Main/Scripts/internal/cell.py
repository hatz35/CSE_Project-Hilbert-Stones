import UnityEngine as ue

'''
1. Class used for defining every cell by certain properties.
2. This will also be used to manipulate cell's properties
'''

class Cell():
    def __init__(self, xRow, xCol, xTypeCell, xIsWalkable, xInteracted, xCellPosition, Commands):
        self.xRow = xRow
        self.xCol = xCol
        self.xTypeCell = xTypeCell
        self.xIsWalkable = xIsWalkable
        self.xInteracted = xInteracted
        self.xCellPosition = xCellPosition
        self.Commands = Commands

def Awake(self):
        """Script attached to the Game Object -> UnityEngine Opening Function"""
        xCellPosition = ue.this.gameObject.transform.position;
