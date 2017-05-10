using UnityEngine;
using System.Collections;

internal class State_Inf_AR_Camera : State {
    internal State_Inf_AR_Camera()
    {
        StateScreen();
    }
	private void StateScreen()
    {
        //Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.Inform_ar_camera.SetActive(true);
        
    }
}
