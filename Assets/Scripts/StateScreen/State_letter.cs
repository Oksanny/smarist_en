
using UnityEngine;

internal class State_letter : State
{ 
    internal State_letter()
    {
        StateScreen();
    }

  

    private void StateScreen()
    {
		DataLevel.Instance.Hand.SetActive (true);
		DataLevel.Instance.Hand2.SetActive(false);
		DataLevel.Instance.Hand.GetComponent<Animator> ().enabled = true;
	
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_letter.SetActive(true);
        DataLevel.Instance.MainLetters.SetActive(true);
        if (DataLevel.Instance.TestState)
        {
            DataLevel.Instance.ButtonNext.SetActive(true);
        }
        else
        {
            DataLevel.Instance.ButtonNext.SetActive(false);
        }
       
        DataLevel.Instance.CameraLetters.SetActive(true);
        DataLevel.Instance.ScanRule = false;



    }
}
