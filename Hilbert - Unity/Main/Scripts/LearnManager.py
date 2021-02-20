import UnityEngine as ue

LoreSlot = ""
InstructionSlot = ""
IndexSlot = ""
TitleSlot = ""
StoneImageSlot = ue.Image(None)
currentIndex = 1

backButton = ue.Button() #manual selection
nextButton = ue.Button() #manual selection
StoneDataButton = ue.Button() #manual selection

class StoneLearnData:
    def __init__(self, xName, xLore, xInstruction, xStoneImage):
        self.xName = xName
        self.xLore = xLore
        self.xInstruction = xInstruction
        self.xStoneImage = xStoneImage

stonedb = gameObject.StoneLearnData("defaultName", "defaultLoreText", "defaultGuideText", ue.Image()) #Manully placed in editor

class LearnManager():
    def __init__(self, LoreSlot, InstructionSlot, IndexSlot, TitleSlot, StoneImageSlot, currentIndex, backButton, nextButton, StoneDataButton):
        self.LoreSlot = LoreSlot
        self.InstructionSlot = InstructionSlot
        self.IndexSlot = IndexSlot
        self.TitleSlot = TitleSlot
        self.StoneImageSlot = StoneImageSlot
        self.currentIndex = currentIndex
        self.backButton = backButton
        self.nextButton = nextButton
        self.StoneDataButton = StoneDataButton

    def CheckEnd():
        if(currentIndex == 1): backButton.SetActive = False
        else: backButton.SetActive = True
        if(currentIndex == len(stonedb)): nextButton.SetActive = False
        else: nextButton.SetActive = True

    def DisplayStone():
        IndexSlot = str(currentIndex)
        TitleSlot = stonedb[currentIndex-1].xName
        LoreSlot = stonedb[currentIndex-1].xLore
        InstructionSlot = stonedb[currentIndex-1].xInstruction
        StoneImageSlot = stonedb[currentIndex-1].xStoneImage

    def Start(self):
        StoneDataButton.interactable = False

    def Update(self):
        DisplayStone()
        CheckEnd()
