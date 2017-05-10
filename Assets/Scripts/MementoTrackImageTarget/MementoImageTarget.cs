using UnityEngine;
using System.Collections;

 public class MementoImageTarget  {

     public int State { get;  private set; }
     public GameObject Letter { get; private set; }
     public GameObject Content { get;private set; }
     public bool CheckLetter { get; set; }
     public bool CheckLoadContent { get; set; }
     public bool CheckCaptureTexture { get; set; }
     public bool StateStatic{ get; set; }
     public bool StateDynamic{ get; set; }
     public bool StartedGame { get; set; }
     public MementoImageTarget(int state)
     {
         this.State = state;
         if (state!=0)
         {
             DataLevel.Instance.ScanRule = false;
             Letter = DataLevel.Instance.Letters[state-1];
             Content = DataLevel.Instance.Contents[state-1];
             DataLevel.Instance.ChangedSate(Mark.letter);
             //for (int i = 0; i < DataLevel.Instance.Letters.Length; i++)
             //{
                // DataLevel.Instance.Letters[i].SetActive(false);
           //  }
            // Debug.Log("Name="+Letter.name);
            Letter.SetActive(true);
         }
         CheckCaptureTexture = false;
         CheckLetter = false;
         CheckLoadContent = false;
         StateStatic = false;
         StateDynamic = false;
         StartedGame = false;
     }
}
