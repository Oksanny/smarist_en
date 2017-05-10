using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload_letter : MonoBehaviour {
	private WritingHandler writingHandler;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClick()
	{
		DataLevel.Instance.Hand.SetActive (true);
		DataLevel.Instance.Hand.GetComponent<Animator> ().enabled = true;
		DataLevel.Instance.Hand2.GetComponent<Animator> ().enabled = false;
		DataLevel.Instance.Hand2.SetActive (false);

		DataLevel.Instance.Full_P.SetActive (false);
		GameObject letters = HierrachyManager.FindActiveGameObjectWithName ("Letters");
		if (letters != null)
			writingHandler = letters.GetComponent<WritingHandler> ();

		if (writingHandler == null) {
			return;
		}
		writingHandler.RefreshProcess ();
	}
	public void ClearLetter()
	{
		DataLevel.Instance.Full_P.SetActive (false);
		GameObject letters = HierrachyManager.FindActiveGameObjectWithName ("Letters");
		if (letters != null)
			writingHandler = letters.GetComponent<WritingHandler> ();

		if (writingHandler == null) {
			return;
		}
		writingHandler.RefreshProcess ();
	}
}
