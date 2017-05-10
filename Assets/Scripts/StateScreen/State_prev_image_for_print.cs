using UnityEngine;
using System.Collections;

internal class State_prev_image_for_print : State
{
    internal State_prev_image_for_print()
    {
        StateScreen();
    }

 

    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_prev_image_for_print.SetActive(true);


    }
}
