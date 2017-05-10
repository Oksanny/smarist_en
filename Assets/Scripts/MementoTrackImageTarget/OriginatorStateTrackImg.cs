using  System;
using System.Collections;

 class OriginatorStateTrackImg  {

     public int State { get; set; }

     public void ResetMemento(MementoImageTarget memento)
     {
         if (State==memento.State)
         {
             State = 0;
             DataLevel.Instance.SetTexture = false;
             // DataLevel.Instance.ResetContent();
         }
         else
         {
             State = memento.State;
         }
     }

     public MementoImageTarget CreateMementoImageTarget()
     {
         return  new MementoImageTarget(State);
     }
}
