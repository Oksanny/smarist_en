using UnityEngine;
using System.Collections;

internal class State_ar_camera : State
{
    internal State_ar_camera()
    {
        StateScreen();
    }

  

    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.ButtonGoToGame.SetActive(false);
        DataLevel.Instance.ButtonCreatedscreenShotARState.SetActive(false);
        DataLevel.Instance.State_ar_camera.SetActive(true);
        DataLevel.Instance.ButtonExitARState.SetActive(true);
      //  DataLevel.Instance.ButtonCreatedscreenShotARState.SetActive(true);
        DataLevel.Instance.ARCamera.SetActive(true);
        DataLevel.Instance.ScaneLine.SetActive(true);
        DataLevel.Instance.ScanRule = true;


    }
}
