using UnityEngine;
using System.Collections;

public class CamGyroAR : MonoBehaviour
{
    public GameObject webPlane;
    private GameObject camParent;
	// Use this for initialization
	void Start () {
	camParent=new GameObject("CamParent");
	    camParent.transform.position = this.transform.position;
	    this.transform.parent = camParent.transform;
        camParent.transform.Rotate(Vector3.right,90);
	    Input.gyro.enabled = true;
        WebCamTexture webCamTexture=new WebCamTexture();
	    webPlane.GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.localRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.x, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
	}
}
