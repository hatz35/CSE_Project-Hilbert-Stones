import UnityEngine as ue
import time

class LoadScreen():
    def __init__(xWaitTime, xSceneName):
        self.waitTime = xWaitTime
        self.waitTime = xSceneName
        #default is 3 seconds

    def LoadScene(sceneName):
        #sceneName is a string, the scene you want to load.
        time.sleep(xWaitTime)
        SceneManager.LoadScene(sceneName);
