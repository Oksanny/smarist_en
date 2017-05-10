using UnityEngine;
using System.Collections;

internal class StateCreatePhoto : State {
    internal StateCreatePhoto()
    {
        StateScreen();
    }

    private void StateScreen()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_CreatePhoto.SetActive(true);
        DataLevel.Instance.SelectTransform.SetActive(true);
        DataLevel.Instance.LeanTouch.SetActive(true);
        DataLevel.Instance.ARCamera.SetActive(true);
    }
}
