using UnityEngine;
using System.Collections;

internal class State_game : State
    
{
    internal State_game()
    {
        StateScreen();
    }
    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_Game.SetActive(true);
        DataLevel.Instance.ARCamera.SetActive(true);
        DataLevel.Instance.ScaneLine.SetActive(true);
        DataLevel.Instance.ButtonPlayGame.SetActive(false);



    }
}
