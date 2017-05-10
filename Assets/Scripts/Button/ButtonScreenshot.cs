using UnityEngine;
using System.Collections;

public class ButtonScreenshot : MonoBehaviour {
    public Mark mark;
    public GameObject []Buttons;
    public DemoScript GalleryScrenshot;
    void OnEnable()
    {
       // UM_Camera.instance.OnImageSaved += OnImageSaved;
     


    }
    void OnDisable()
    {
        //UM_Camera.instance.OnImageSaved -= OnImageSaved;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnClickButton()
    {
        Debug.Log("ButtonScreenshot");
        foreach (GameObject button in Buttons)
        {
            button.SetActive(false);
        }
      GalleryScrenshot.OnSaveScreenshotPress();
      foreach (GameObject button in Buttons)
      {
          button.SetActive(true);
      }
       // UM_Camera.instance.SaveScreenshotToGallery();
        
    }
    void OnImageSaved(UM_ImageSaveResult result)
    {
        if (result.IsSucceeded)
        {
            //no image path for IOS
            foreach (GameObject button in Buttons)
            {
                button.SetActive(true);
            }
            
           // if (DataLevel.Instance.TexturescreenShot)
           // {
           //     Destroy(DataLevel.Instance.TexturescreenShot);
           //
           // }
           // DataLevel.Instance.ChangedSate(mark);
       
            new MobileNativeMessage("Image Saved", result.imagePath);
        }
        else
        {
            new MobileNativeMessage("Failed", "Image Save Failed");
        }
    }
    
}
