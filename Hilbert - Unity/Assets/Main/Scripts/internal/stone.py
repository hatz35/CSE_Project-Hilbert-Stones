import UnityEngine as ue

'''
1. Class used for defining every stone by certain properties.
2. This will also be used to manipulate stone's properties
'''
class stone():
    def __init__(self, xRow, xCol, xTypeStone, xIsAlive, xIsActive, xIsTeamA):
        self.xRow = xRow
        self.xCol = xCol
        self.xTypeStone = xTypeStone
        self.xIsAlive = False
        self.xIsActive = False
        self.xIsTeamA = True
