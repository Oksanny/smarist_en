using UnityEngine;
using System.Collections;

internal class State_Inf_main_menu : State
{
    internal State_Inf_main_menu()
    {
        StateScreen();
    }



    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.InformMainMenu.SetActive(true);
        DataLevel.Instance.ScanRule = false;



    }
}