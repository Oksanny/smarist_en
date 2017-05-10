using UnityEngine;
using System.Collections;
internal class State_list_letters : State    
{
    internal State_list_letters()     
    {
        StateScreen(); 
    }

  

    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_list_letters.SetActive(true);


    }
}

