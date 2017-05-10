using UnityEngine;
using System.Collections;

public class ButtonMainMenu : MonoBehaviour
{
    public Mark mark;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyUp(KeyCode.Escape))
	    {
            DataLevel.Instance.ChangedSate(mark);
	    }
	}

	public void OnClickButton()
    {
		Debug.Log ("Check");
        DataLevel.Instance.ChangedSate(mark);
    }
}
