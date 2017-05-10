using UnityEngine;
using System.Collections;

public interface ImageManagerInterface
{

    void SetStart_StaticState();

    void SetStart_DynamicState();
    void SetActive_StaticPart(bool state);
    void SetActive_DynamicPart(bool state);
    void Play_StaticPart();
    void Play_DynamicPart();
    void SetActiveContent(bool state);
    void SetScore();
    void GoToPhotoState();

}
