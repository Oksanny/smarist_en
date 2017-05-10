using UnityEngine;
using System.Collections;
public class ManagerSateScreen
{
    internal State State { get; set; }
    public ManagerSateScreen() 
    { State = new State_main_menu();
        //DataLevel.Instance.CurrentState = Mark.main_menu;
    }
    public void FindOut(Mark mark) 
    { State.HandleMark(this, mark); }
} 
