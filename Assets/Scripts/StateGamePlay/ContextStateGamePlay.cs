using UnityEngine;
using System.Collections;

 class ContextStateGamePlay  {

     public StateGamePlay State { get; set; }

     public ContextStateGamePlay(StateGamePlay state)
     {
         this.State = state;
     }

     public void Request()
     {
         
     }
}
