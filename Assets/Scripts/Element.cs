using UnityEngine;
using System.Collections;

public enum StatusElement
{
    start,
    end,
    none,
    out_line,
    tutor

}
public class Element : MonoBehaviour
{
    public StatusElement Status;
    public int Number;
    public Letter ControllerLetter;
    //[HideInInspector]
    public Renderer colorPlane;

    void Awake()
    {
        colorPlane = GetComponent<Renderer>();
    }
	// Use this for initialization
	void Start ()
	{
         
	   
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        Debug.Log("OnMouseDown=" + gameObject.name);
        if (Status == StatusElement.start)
        {
            ControllerLetter.SetStart();
        }
    }
    void OnMouseUp()
    {

        Debug.Log("MouseUp=" + gameObject.name);
        if( ControllerLetter.StatePart == StatePartLine.start)
        {
            Debug.Log("MouseUp=" + gameObject.name);
            ControllerLetter.SetIdle();
        }

    }

    void OnMouseOver()
    {
       // Debug.Log("OnMouseOver=" + gameObject.name);
        if (Status == StatusElement.start&&ControllerLetter.StatePart==StatePartLine.end)
        {
            ControllerLetter.SetStart();
        }
        if (Status == StatusElement.out_line)
        {
            Debug.Log("OnMouseOver=" + gameObject.name);
            ControllerLetter.SetIdle();
        }
        
       ControllerLetter.StartGo(Number);
       if (Status == StatusElement.end)
       {
           ControllerLetter.SetStateEnd();
       }
       
       
    }
}
