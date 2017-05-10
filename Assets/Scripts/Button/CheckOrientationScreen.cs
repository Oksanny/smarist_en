using UnityEngine;
using System.Collections;

public class CheckOrientationScreen : MonoBehaviour
{
    public GameObject []IconLef;
    public GameObject[] IconRight;

    
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            for (int i = 0; i < IconLef.Length; i++)
            {
               IconLef[i].GetComponent<RectTransform>().sizeDelta=new Vector2(160f,160f);
               IconLef[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(100f, -180f * (i + 1) + 80f);
            }
            for (int i = 0; i < IconRight.Length; i++)
            {
                IconRight[i].GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 160f);
                IconRight[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-100f, -180f * (i+1) + 80f);
            }
        }
        if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            for (int i = 0; i < IconLef.Length; i++)
            {
                IconLef[i].GetComponent<RectTransform>().sizeDelta = new Vector2(260f, 260f);
                IconLef[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(180f, -310f * (i+1) + 130f);
            }
            for (int i = 0; i < IconRight.Length; i++)
            {
                IconRight[i].GetComponent<RectTransform>().sizeDelta = new Vector2(260f, 260f);
                IconRight[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-180f, -310f * (i + 1) + 130f);
            }
        }
	}
}
