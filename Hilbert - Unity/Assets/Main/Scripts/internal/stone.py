import UnityEngine as ue

StoneData = {
    "xRow" : 0, "xCol" : 0, "xIsA" : False, "xIsAlive" : True, "xIsPlaced" : False, "xIsActive" : True, "xStoneImage" : ue.Image(),
    "xBoosted" : False, "xBlocked" : False, "xName" : "defaultName",
    "xTypeCell" : "Standard", "xHealth" : 1, "xAttackPower" : 0, "xScorePerTurn" : 0, "xMovementHorizontal" : 0,
    "xMovementVertical" : 0, "xMovementDiagonal" : 0, "xCanMoveOnlyForward" : False, "xCanMoveFromThrone" : True, "xScoreExponentialGrowth" : False,
    "xSimpleMergePossible" : False, "xMergeMultiplier" : 0, "xThroneExplosion" : False, "xThroneExplosionSteal" : 0
    }
'''
1. Class used for defining every stone by certain properties.
2. This will also be used to manipulate stone's properties
'''
class stone():
    def __init__(self, StoneData):
        self.StoneDat["xRow"] = StoneData["xRow"]
        self.StoneData["xCol"] = StoneData["xCol"]
        self.StoneData["xIsA"] = StoneData["xIsA"]
        self.StoneData["xIsAlive"] = StoneData["xIsAlive"]
        self.StoneData["xIsPlaced"] = StoneData["xIsPlaced"
        self.StoneData["xIsPlaced"] = StoneData["xIsPlaced"]
        self.StoneData["xStoneImage"] = StoneData["xStoneImage"]
        self.StoneData["xBoosted"] = StoneData["xBoosted"]
        self.StoneData["xBlocked"] = StoneData["xBlocked"]
        self.StoneData["xName"] = StoneData["xName"]
        self.StoneData["xTypeCell"] = StoneData["xTypeCell"]
        self.StoneData["xHealth"] = StoneData["xHealth"]
        self.StoneData["xAttackPower"] = StoneData["xAttackPower"]
        self.StoneData["xScorePerTurn"] = StoneData["xScorePerTurn"]
        self.StoneData["xMovementHorizontal"] = StoneData["xMovementHorizontal"]
        self.StoneData["xMovementVertical"] = StoneData["xMovementVertical"]
        self.StoneData["xMovementDiagonal"] = StoneData["xMovementDiagonal"]
        self.StoneData["xCanMoveOnlyForward"] = StoneData["xCanMoveOnlyForward"]
        self.StoneData["xCanMoveFromThrone"] = StoneData["xCanMoveFromThrone"]
        self.StoneData["xScoreExponentialGrowth"] = StoneData["xScoreExponentialGrowth"]
        self.StoneData["xSimpleMergePossible"] = StoneData["xSimpleMergePossible"]
        self.StoneData["xMergeMultiplier"] = StoneData["xMergeMultiplier"]
        self.StoneData["xThroneExplosion"] = StoneData["xThroneExplosion"]
        self.StoneData["xThroneExplosionSteal"] = StoneData["xThroneExplosionSteal"]
