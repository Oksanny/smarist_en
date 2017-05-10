using UnityEngine;
using System.Collections;

internal class State_Inf_List_Letter : State {

	// Use this for initialization
    internal State_Inf_List_Letter()
    {
        StateScreen();
	}
    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.Inform_list_letter.SetActive(true);
        



    }
	
}
