internal class State_settings : State
{
    
    internal State_settings()
    {
        StateScreen();
    }

   

    private void StateScreen()
    {
        DataLevel.Instance.DisableGameObjectForState();
        DataLevel.Instance.State_settings.SetActive(true);


    }
}
