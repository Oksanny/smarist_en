using UnityEngine;
using System.Collections;

internal class State_Inf_Prev_Image : State {

	// Use this for initialization
    internal State_Inf_Prev_Image()
    {

        StateScreen();
    }
    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.Inform_prev_image.SetActive(true);
       



    }

}
