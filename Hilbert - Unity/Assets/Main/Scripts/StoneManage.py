import UnityEngine as ue

#xAllCells = gameObject.Cell(0, 0, "Normal", True, True, ue.Vector2D(0,0), "") Manully Done in editor
#xBoxes = ue.FindGameObjectsWithTag("Boxes")

class StoneManage():
    def __init__(self, xAllStones, xBoxes):
        self.xAllCells = xAllCells
        self.xAllCells = xBoxes

    private void Awake()
    {
        WhichStone();
        ThrowInInventory();


    }

    private void WhichStone()
    {
        foreach(GameObject stone in stones)
        {
            Stone stonescript = stone.GetComponent<Stone>();
            SpriteRenderer sr = stone.GetComponent<SpriteRenderer>();
            if (stonescript.xTypeStone == "Gold")
            {
                sr.color = new Color(1f, 0.843f, 0f);
            }
            else if (stonescript.xTypeStone == "Copper")
            {
                sr.color = new Color(0.722f, 0.451f, 0.2f);
            }
            else if (stonescript.xTypeStone == "Silver")
            {
                sr.color = new Color(0.753f, 0.753f, 0.753f);
            }
            else if (stonescript.xTypeStone == "Iron")
            {
                sr.color = new Color(0.6314f, 0.6157f, 0.5804f);
            }
            else if (stonescript.xTypeStone == "Ruby")
            {
                sr.color = new Color(0.878f, 0.067f, 0.373f);
            }

            else if (stonescript.xTypeStone == "Diamond")
            {
                sr.color = new Color(0.7255f, 0.949f, 1f);
            }


        }

    }
    private void ThrowInInventory()
    {
        int sn = 0;
        foreach (GameObject box in boxes)
        {
            try
            {
                stones[sn].transform.position = box.transform.position;
            }

            catch (Exception e)
            {
                print(e);
            }

            sn += 1;
        }
    }
}
