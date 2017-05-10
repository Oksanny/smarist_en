/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class ColorDefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public int NumberLetter;
        public bool Payment;
        public GameObject MainGameObject;
        public GameObject[] ContentGameObject;
        public Animator[] Animators;
        public Material MaterialContent;
        public ScanLine scanLine;
        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
			Debug.Log ("Rule="+DataLevel.Instance.ScanRule);
            if (DataLevel.Instance.ScanRule)
            {
                if (DataLevel.Instance.GetOriginatorStateState() == NumberLetter)
                {
                    if (!DataLevel.Instance.GetCheckLetter())
                    {
						Debug.Log ("Rule=2");
                        DataLevel.Instance.SetTrackFound(gameObject, MainGameObject);
                    }
                    else
                    {
                        if (DataLevel.Instance.GetCheckCaptureTexture())
                        {
							Debug.Log ("Rule=3");
                            Debug.Log("Seta ColorTrack");
                            DataLevel.Instance.ButtonGoToGame.SetActive(true);
                            DataLevel.Instance.ButtonCreatedscreenShotARState.SetActive(true);
                            DataLevel.Instance.ImageManagerInterface.SetActiveContent(true);
                           // DataLevel.Instance.ButtonscanGame.SetActive(true);
                            DataLevel.Instance.ButtonReloadGame.SetActive(true);
                            ShowScanLine(false);
                            if (!DataLevel.Instance.GetMementoImageTarget().StartedGame)
                            {
                                DataLevel.Instance.ButtonPlayGame.SetActive(true);
                            }
                            else
                            {
                                DataLevel.Instance.ButtonPlayGame.SetActive(false);
                            }
                        }
                        
                    }

                }
                else
                {
                    DataLevel.Instance.SetTrackFound(gameObject, MainGameObject);
                }

            }




            //     Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            //     Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            //
            //     // Enable rendering:
            //     foreach (Renderer component in rendererComponents)
            //     {
            //         component.enabled = true;
            //     }
            //
            //     // Enable colliders:
            //     foreach (Collider component in colliderComponents)
            //     {
            //         component.enabled = true;
            //     }
            // foreach (Animator animator in Animators)
            // {
            //    // animator.enabled = true;
            // }
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost()
        {

        //    if (DataLevel.Instance.GetOriginatorStateState() == NumberLetter)
        //    {
                if (DataLevel.Instance.GetCheckLetter())
                {
                    DataLevel.Instance.ButtonGoToGame.SetActive(false);
                    DataLevel.Instance.ButtonCreatedscreenShotARState.SetActive(false);
                    DataLevel.Instance.ButtonPlayGame.SetActive(false);
                    DataLevel.Instance.ImageManagerInterface.SetActiveContent(false);
                   // DataLevel.Instance.ButtonscanGame.SetActive(false);
                    DataLevel.Instance.ButtonReloadGame.SetActive(false);
                    DataLevel.Instance.ButtonPlayGame.SetActive(false);
                }


       //     }
            ShowScanLine(true);
            // Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            // Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
            //
            // // Disable rendering:
            // foreach (Renderer component in rendererComponents)
            // {
            //     component.enabled = false;
            // }
            //
            // // Disable colliders:
            // foreach (Collider component in colliderComponents)
            // {
            //     component.enabled = false;
            // }
            // foreach (Animator animator in Animators)
            // {
            //    // animator.enabled = false;
            // }
          //  Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }
        private void ShowScanLine(bool show)
        {
            // Toggle scanline rendering
            if (scanLine != null)
            {
                Renderer scanLineRenderer = scanLine.GetComponent<Renderer>();
                if (show)
                {
                    // Enable scan line rendering
                    if (!scanLineRenderer.enabled)
                        scanLineRenderer.enabled = true;

                    scanLine.ResetAnimation();
                }
                else
                {
                    // Disable scanline rendering
                    if (scanLineRenderer.enabled)
                        scanLineRenderer.enabled = false;
                }
            }
        }
        private void OnDialogClose(AndroidDialogResult result)
        {

            //parsing result
            switch (result)
            {
                case AndroidDialogResult.YES:
                    DataLevel.Instance.ScanRule = true;
                    Debug.Log("Yes button pressed");
                    break;
                case AndroidDialogResult.NO:
                    DataLevel.Instance.ScanRule = true;
                    Debug.Log("No button pressed");
                    break;

            }

            //AN_PoupsProxy.showMessage("Result", result.ToString() + " button pressed");
        }
        #endregion // PRIVATE_METHODS
    }

}
