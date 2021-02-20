import UnityEngine as ue
from internal.cell import Cell

xAllCells = gameObject.Cell(0, 0, "Normal", True, True, ue.Vector2D(0,0), "") #Manully Done in editor
#Look at Class Cell

class CellManage():
    def __init__(self, xAllCells):
        self.xAllCells = xAllCells
    def onValidate(self):
        #Rename()
        #Use only when needed
        FillPoint()
        pass
    def Rename():
        for i in xAllCells:
            i.ue.name = "Cell " + str(i)
    def FillPoint():
        points = []
        xc = 6
        yc = 9
        for a_row in range(1,15):
            halfdone = False
            for a_col in range(1,15):
                if a_col > xc and a_col < yc:
                    points.append((a_row, a_col))
            if a_row >= 8: halfdone = True
            if halfdone == False and a_row % 2 == 0:
                xc -= 2
                yc += 2

            elif halfdone == False and a_row % 2 == 0:
                xc += 2
                yc -= 2

        for a, b in enumerate(xAllCells): b.xRow, b.xCol = points[a][0], points[a][1]
