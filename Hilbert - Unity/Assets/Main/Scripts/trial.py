from internal.cell import Cell

xAllCells = []

for i in range(100):
    xAllCells.append(Cell(0, 0, "Normal", True, True, (0,2), ""))

def FillPoint():
    points = []
    xc = 6;
    yc = 9;

    for a_row in range(1,15):
        halfdone = False

        for a_col in range(1,15):
            if a_col > xc and a_col < yc:
                points.append((a_row, a_col))

        if a_row >= 8:
            halfdone = True;

        if halfdone == False and a_row % 2 == 0:
            xc -= 2
            yc += 2

        elif halfdone == False and a_row % 2 == 0:
            xc += 2;
            yc -= 2;

    for a, b in enumerate(xAllCells):
        b.xRow, b.xCol = points[a][0], points[a][1]

FillPoint()
for k in xAllCells:
    print(str(k.xRow) + " - " + str(k.xCol))
