import UnityEngine as ue

xAllCells = gameObject.Cell(0, 0, "Normal", True, True, ue.Vector2D(0,0), "") #Manully Done in editor
xBoxes = ue.FindGameObjectsWithTag("Boxes")

class StoneManage():
    def __init__(self, xAllStones, xBoxes):
        self.xAllCells = xAllCells
        self.xAllCells = xBoxes

def WhichStone():
    for stone in xAllStones:
        sr = ue.stone.GetComponent("SpriteRenderer")
        sr.sprite = stone.xStoneImage

def PlaceInInventory():
    for a, box in enumerate(xBoxes):
        try:
            xAllStones[a].ue.transform.position = box.ue.transform.position;
        except:
            pass

def Awake(self):
    WhichStone()
    PlaceInInventory()
