using UnityEngine;
using System.Collections;

internal class StateGamePlayStatic : StateGamePlay {
    public StateGamePlayStatic()
    {
        
    }
    public override void Handle(ContextStateGamePlay context)
    {
        context.State=new StateGamePlayDynamic();
    }
}
