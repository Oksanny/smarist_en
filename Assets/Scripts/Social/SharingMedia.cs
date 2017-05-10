using UnityEngine;
using System.Collections;

public class SharingMedia : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Sharing_Media()
    {
        UM_ShareUtility.ShareMedia("Title", "Some text to share", DataLevel.Instance.TexturescreenShot);
    }
}
