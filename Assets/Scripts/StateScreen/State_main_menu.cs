using UnityEngine;
using System.Collections;

internal class State_main_menu : State
{
    internal State_main_menu()
    {
        StateScreen();
    }

  

    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_main_menu.SetActive(true);
       



    }
}
