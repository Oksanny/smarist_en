using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class StateFinishedWriteLetter : State {
	internal StateFinishedWriteLetter()
	{
		StateScreen();
	}
	private void StateScreen()
	{
		
		DataLevel.Instance.Hand.GetComponent<Animator> ().enabled = false;
		DataLevel.Instance.Hand2.GetComponent<Animator> ().enabled = false;
		DataLevel.Instance.Hand.SetActive (false);
		DataLevel.Instance.Hand2.SetActive (false);
		DataLevel.Instance.ReloadLetter.GetComponent<Reload_letter> ().ClearLetter ();
		DataLevel.Instance.Full_P.SetActive (true);
		DataLevel.Instance.GetMementoImageTarget().CheckLetter = true;
		Debug.Log ("finished");

		DataLevel.Instance.ButtonNext.SetActive (true);
		DataLevel.Instance.ScanRule = false;
		//DataLevel.Instance.GetComponent<Animator> ().enabled = false;
		DataLevel.Instance.Hand2.SetActive (false);
	
	}
}
