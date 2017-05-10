using UnityEngine;
using System.Collections;

public class SharingEB : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SharingFacebook()
    {
        UM_ShareUtility.FacebookShare("Hello Facebook", DataLevel.Instance.TexturescreenShot);
    }
}
