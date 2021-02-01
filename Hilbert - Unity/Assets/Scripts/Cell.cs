using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int xRow;
    public int xCol;
    public string xTypeCell;
    public bool xIsWalkable = true;
    public bool xInteracted = false;

    [Space(20)]
    public Stone xCurrentStone;
    private Vector2 xCellPosition;
    [TextArea(6, 10)]
    public string[] Commands;


    void Awake()
    {
        xCellPosition = this.gameObject.transform.position;

    }

}
