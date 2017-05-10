using UnityEngine;
using System.Collections;

public class ControllerAnimationEyes : MonoBehaviour {
    public Renderer colorPlane;
    public GameObject Clone;
	// Use this for initialization
	void Start () {
        colorPlane = GetComponent<Renderer>();
        Debug.Log("Material="+colorPlane.materials[1].name);
        Debug.Log("Material=" + colorPlane.materials[2].name);
      //  Vector2 vect = new Vector2(0.5f, 0);
       // colorPlane.materials[1].SetTextureOffset("_MainTex", vect);
       // colorPlane.materials[2].SetTextureOffset("_MainTex", vect);
	}
	
	// Update is called once per frame
	void Update () {
	  if (Clone.GetComponent<BoxCollider>().enabled==true)
	  {
          Vector2 vect=new Vector2(0,0);
          colorPlane.materials[1].SetTextureOffset("_MainTex", vect);
          colorPlane.materials[2].SetTextureOffset("_MainTex", vect);
	  }
      if (Clone.GetComponent<BoxCollider>().enabled == false)
      {
          Vector2 vect = new Vector2(0.5f, 0);
          colorPlane.materials[1].SetTextureOffset("_MainTex", vect);
          colorPlane.materials[2].SetTextureOffset("_MainTex", vect);
      }
	}
}
