using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{


    public GameObject[] Cells;
    void OnValidate()
    {
        //Rename();
        //FillPoint();

    }

 

    
    void FillPoint()
    {

        var points = new List<(int, int)>();
        int xc = 6;
        int yc = 9;
        int i = 1;
        foreach (int a_row in Enumerable.Range(1, 15))
        {
            bool halfdone = false;

            foreach (int a_col in Enumerable.Range(1, 15))
            {
                if (a_col > xc && a_col < yc)
                {
                    Cell cellscript = Cells[i].GetComponent<Cell>();
                    points.Add((a_row, a_col));
                }
            }
            print(xc);
            if (a_row >= 8)
            {
                halfdone = true;
            }
            if (halfdone == false && a_row % 2 == 0)
            {
                xc -= 2;
                yc += 2;
            }
            else if (halfdone == true && a_row % 2 == 0)
            {
                xc += 2;
                yc -= 2;
            }

        }

        int ii = 0;
        foreach (GameObject Cell in Cells)
        {
            Cell cellScript = Cell.GetComponent<Cell>();
            cellScript.xRow = points[ii].Item1;
            cellScript.xCol = points[ii].Item2;
            ii += 1;

        }
    }
   

    void Rename()
    {
        int i = 0;
        foreach (GameObject Cell in Cells)
        {
            i += 1;
            Cell.name = "Cell " + i.ToString();
        }


    }
}
