using UnityEngine;

internal class StateScreenShot : State
{

    internal StateScreenShot()
    {
        
       // UM_Camera.instance.OnImagePicked += OnImage;
        //UM_Camera.instance.GetImageFromGallery();
        StateScreen();
    }

   

    private void StateScreen()
    {
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.ARCamera.SetActive(true);
        DataLevel.Instance.StateScreenShot.SetActive(true);
       // if (DataLevel.Instance.TexturescreenShot)
       // {
       //     DataLevel.Instance.StateScreenShot.GetComponent<UnityEngine.UI.Image>().sprite = Sprite.Create(DataLevel.Instance.TexturescreenShot, new Rect(0, 0, DataLevel.Instance.TexturescreenShot.width, DataLevel.Instance.TexturescreenShot.height), new Vector2(0.5f, 0.5f));
       //
       // }
       //

    }
    private void OnImage(UM_ImagePickResult result)
    {
        if (result.IsSucceeded)
        {
            

            DataLevel.Instance.TexturescreenShot = result.image;
        }
        UM_Camera.instance.OnImagePicked -= OnImage;
    }
}
