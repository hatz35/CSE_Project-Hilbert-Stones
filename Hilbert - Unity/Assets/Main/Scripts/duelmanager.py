import UnityEngine as ue

winningAmount = 300
numberOfTurns = 0
playerAturn = True
blockerA
blockerB
turnA
turnB
xScoreA = 0
xScoreB = 0
scoreA = ue.TextMeshProUGUI
scoreB = ue.TextMeshProUGUI

SM1 = StoneManager
SM2 = StoneManage

if (playerAturn):
    blockerB.SetActive(True)
    blockerA.SetActive(False)
    turnA.SetActive(True)
    turnB.SetActive(False)
else:
    blockerA.SetActive(True)
    blockerB.SetActive(False)
    turnA.SetActive(False)

scoreA.text = xScoreA.ToString()
scoreB.text = xScoreB.ToString()

checkEnd()



def checkEnd():
    if (xScoreA >= winningAmount):
        GEN.DeclareWinner(True, xScoreA - xScoreB)

    else if (xScoreB >= winningAmount):
        GEN.DeclareWinner(False, xScoreB - xScoreA)



def ReminderToAddScore():
    SM1.WhichStoneInThrone()
    SM2.WhichStoneInThrone()


def ReminderToCheckUplift():
    SM1.WhichStoneInUplift()
    SM2.WhichStoneInUplift()

def AddScore( amount):
    if (playerAturn):
        xScoreA += amount
    else if (!playerAturn):
        xScoreB += amount
