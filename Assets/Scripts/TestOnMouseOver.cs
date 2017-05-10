using UnityEngine;
using System.Collections;

public class TestOnMouseOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseEnter()
    {
        
    }
    void OnMouseOver()
    {
        Debug.Log("Name="+gameObject.name);
    }

    private void OnMouseExit()
    {
    }
}
