using UnityEngine;
using System.Collections;

internal class State_overlay_buy : State
{
    internal State_overlay_buy()
    {
        StateScreen();
    }

   

    private void StateScreen()
    {
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_overlay_buy.SetActive(true);


    }
}
