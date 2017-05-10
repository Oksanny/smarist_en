using UnityEngine;
using System.Collections;

internal class StateGamePlayDynamic : StateGamePlay  {
    public StateGamePlayDynamic()
    {
        
    }
    public override void Handle(ContextStateGamePlay context)
    {
        context.State=new StateGamePlayStatic();
    }
}
