using UnityEngine;
using System.Collections;

public class ButtonSelectLetterPrint : MonoBehaviour
{
    public Mark mark;
    public int NumberLetter;
    public bool rules;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonPrev()
    {
        if (rules)
        {
            Debug.Log("ButtonSelectLetterPrint");
            DataLevel.Instance.SetPrevImageCounter(NumberLetter);
            DataLevel.Instance.ChangedSate(mark);
        }
        
    }
}
