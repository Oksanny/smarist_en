using UnityEngine;
using System.Collections;

internal class State_Inf_Photo : State {
    internal State_Inf_Photo()
    {
        StateScreen();
    }
    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.Inform_Photo.SetActive(true);
       
    }
}
