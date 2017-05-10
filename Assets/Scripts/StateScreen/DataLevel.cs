using UnityEngine;
using System.Collections;
using Vuforia;

public class DataLevel : SingletonBehaviour<DataLevel>
{
	
	private WritingHandler writingHandler;
    public DemoScript GalleryScrenshot;
    public ImageManagerInterface ImageManagerInterface; 
    public bool TestState;
    public string State;
    public Mark CurrentState;
    public string CurrenLinkForPrint;
    public string[] LinksPrint;
    [Header("RULE")] [Space(20)]
    public bool SetTexture;

    public bool ScanRule;

[Header("UI_Panel")]
    public GameObject State_ar_camera;
    public GameObject State_Game;
    public GameObject State_list_letters;
    public GameObject State_main_menu;
    public GameObject State_overlay_buy;
    public GameObject State_prev_image_for_print;
    public GameObject State_settings;
    public GameObject StateScreenShot;
    public GameObject State_letter;
    public GameObject State_CreatePhoto;
    public GameObject InformMainMenu;
    public GameObject Inform_list_letter;
    public GameObject Inform_prev_image;
    public GameObject Inform_ar_camera;
    public GameObject Inform_Photo;
    [Header("GameObject for change state")]
    [Space(20)]
    public Sprite []Counters;

    public GameObject ScaneLine;
    public GameObject Prev_Image_Counter ;
   
    public GameObject CameraLetters;
    public GameObject MainLetters;
   
    public GameObject ButtonNext;
    public GameObject SelectTransform;
    public GameObject LeanTouch;
    [Header("GameObject for change of StateARCamera")]
    [Space(20)] 
    public GameObject Button_Info_AR;
    public GameObject ButtonExitARState;
    public GameObject ButtonGoToGame;
    public GameObject ARCamera;
    public GameObject ButtonCreatedscreenShotARState;
	public GameObject ReloadLetter;
    [Header("GameObject for change of StateGame")]
    [Space(20)] 
   // public GameObject ButtonscanGame;
    public GameObject ButtonPlayGame;
    public GameObject ButtonReloadGame;
    [Header("GameObject Content")]
    [Space(20)]
    public GameObject[] Contents;

    public GameObject[] Letters;
    public GameObject CurrentContent;
    public GameObject ImageTarget;
    public RenderTextureCamera RenderTextureCamera;
    public Region_Capture RegionCapture;
    private OriginatorStateTrackImg OriginatorStateTrack;
    private CareTakerImageTarget CareTakerImage;
    private ManagerSateScreen managerSateScreen;
    [Header("Resources")]
    [Space(20)]
	public GameObject Hand;
	public GameObject Hand2;
	public GameObject Full_P;
	public GameObject[] Smile_particle;
    public Texture2D TexturescreenShot;
	// Use this for initialization
    void Awake()
    {
        // ResetContent();
        CurrentState = Mark.init;
        managerSateScreen = new ManagerSateScreen();
        OriginatorStateTrack = new OriginatorStateTrackImg();
        CareTakerImage = new CareTakerImageTarget();
        OriginatorStateTrack.State = 0;
        ScanRule = true;
    }
	void Start ()
	{
	  

	}
	
	// Update is called once per frame
	void Update () {
	//Debug.Log("State="+OriginatorStateTrack.State);
      //  State = OriginatorStateTrack.State;
	}

    public void PrintLettes()
    {
        Application.OpenURL(CurrenLinkForPrint);
    }
    public void SetPrevImageCounter(int number)
    {
        Prev_Image_Counter.GetComponent<UnityEngine.UI.Image>().sprite = Counters[number-1];
        CurrenLinkForPrint = LinksPrint[number - 1];
    }
    public void ChangedSate(Mark mark)
    {
        managerSateScreen.FindOut(mark);
        CurrentState = mark;
    }

    public void DisableGameObjectForState()
    {
		Full_P.SetActive (false);
        State_main_menu.SetActive(false);
        State_ar_camera.SetActive(false);
        State_Game.SetActive(false);
        State_list_letters.SetActive(false);
        State_overlay_buy.SetActive(false);
        State_prev_image_for_print.SetActive(false);
        State_settings.SetActive(false);
        StateScreenShot.SetActive(false);
        State_letter.SetActive(false);
        State_CreatePhoto.SetActive(false);
        InformMainMenu.SetActive(false);
        Inform_list_letter.SetActive(false);
        Inform_prev_image.SetActive(false);
        Inform_ar_camera.SetActive(false);
        Inform_Photo.SetActive(false);
        MainLetters.SetActive(false);
        CameraLetters.SetActive(false);
        SelectTransform.SetActive(false);
        LeanTouch.SetActive(false);
        ScaneLine.SetActive(false);
        for (int i = 0; i < Contents.Length; i++)
        {
            //Contents[i].SetActive(false);
        }
        if (CurrentState!=Mark.init)
        {
            ARCamera.SetActive(false);
        }
        
    }

    public void CraetedScreenShot()
    {
        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
       
        }
        if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
           
        }
        if (Screen.orientation == ScreenOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
         
        }
        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown)
        {
            Screen.orientation = ScreenOrientation.PortraitUpsideDown;
            
        }
        State_CreatePhoto.SetActive(false);
        GalleryScrenshot.OnSaveScreenshotPress();
    }
    public void ExitScreenShotState()
    {
        if (CareTakerImage != null && CareTakerImage.Memento != null)
        {
            if (CareTakerImage.Memento.StateStatic)
            {
                ChangedSate(Mark.ar_camera);
            }
            if (CareTakerImage.Memento.StateDynamic)
            {
                ChangedSate(Mark.game);
            }
            
           
        }
    }
    public MementoImageTarget GetMementoImageTarget()
    {
        if (CareTakerImage != null && CareTakerImage.Memento != null)
        {
            return CareTakerImage.Memento;
        }
        return null;
    }

    public void MementoStateDynamicGamePlay()
    {
        if (CareTakerImage != null && CareTakerImage.Memento != null)
        {
            CareTakerImage.Memento.StateDynamic = true;
            CareTakerImage.Memento.StateStatic = false;
        }
    }
    public void MementoStateStaticGamePlay()
    {
        if (CareTakerImage!=null&&CareTakerImage.Memento != null)
        {
            CareTakerImage.Memento.StateDynamic = false;
            CareTakerImage.Memento.StateStatic = true;
        }
    }
    public void MementoStateGoGamePlay(bool state)
    {
        if (CareTakerImage != null && CareTakerImage.Memento != null)
        {
            CareTakerImage.Memento.StartedGame = state;
          
        }
    }
    public void GoToGame()
    {
        ImageManagerInterface.SetStart_DynamicState();
    }
    public void GoToCreatedPhoto()
    {
        ImageManagerInterface.GoToPhotoState();
    }
    public void BackToStatic()
    {
        ImageManagerInterface.SetStart_StaticState();
    }

    public void PlayGame()
    {
        if (ImageManagerInterface!=null)
        {
            ImageManagerInterface.Play_DynamicPart();
        }
    }
    public void ExitARState()
    {
        if (OriginatorStateTrack != null && OriginatorStateTrack.State != 0)
        {
            //OriginatorStateTrack.State = imageTarget;
            OriginatorStateTrack.ResetMemento(CareTakerImage.Memento);
            
        }
       
    }

    public void ReLoadDynamic()
    {
        if (ImageManagerInterface != null)
        {
            ImageManagerInterface.SetStart_DynamicState();
            ButtonPlayGame.SetActive(true);
        }
    }
    public void ReloadARState()
    {

        if (OriginatorStateTrack != null && OriginatorStateTrack.State != 0)
        {
            //OriginatorStateTrack.State = imageTarget;
            OriginatorStateTrack.ResetMemento(CareTakerImage.Memento);

        }
        if (ImageManagerInterface!=null)
        {
            ImageManagerInterface.SetActiveContent(false);
        }
        ARCamera.SetActive(false);
        ARCamera.SetActive(true);
    }
    public void SetTrackLost(string imageTarget)
    {
        if (OriginatorStateTrack!=null&&OriginatorStateTrack.State!=0)
        {
            //OriginatorStateTrack.State = imageTarget;
            OriginatorStateTrack.ResetMemento(CareTakerImage.Memento);
        }
        
    }

    public void SetTrackFound(GameObject imageTarget, GameObject content)
    {
        
            OriginatorStateTrack.State = imageTarget.GetComponent<ColorDefaultTrackableEventHandler>().NumberLetter;
            CareTakerImage.Memento = OriginatorStateTrack.CreateMementoImageTarget();
            RegionCapture.ImageTarget = imageTarget;
            CurrentContent = content;
        ImageManagerInterface = content.GetComponent<ImageManagerInterface>();
            // content.SetActive(true);
            RecalculateRegionSize();
            RecalculateTextureSize();
            SetTexture = true;
       
            

        
        
    }
    public void SetCheckCaptureTexture(bool check)
    {
        if (CareTakerImage.Memento != null)
        {
             CareTakerImage.Memento.CheckCaptureTexture=check;
        }
       

    }
    public bool GetCheckCaptureTexture()
    {
        if (CareTakerImage.Memento != null)
        {
            return CareTakerImage.Memento.CheckCaptureTexture;
        }
        else
        {
            return false;
        }

    }
    public bool GetCheckLetter()
    {
        if (CareTakerImage.Memento != null)
        {
            return CareTakerImage.Memento.CheckLetter;
        }
        else
        {
            return false;
        }
       
    }
    public int GetOriginatorStateState()
    {
        if (OriginatorStateTrack!=null)
        {
            return OriginatorStateTrack.State;
        }
        else
        {
            return 0;
        }
       
    }
    public void RecalculateRegionSize()
    {
        RegionCapture.RecalculateRegionSize();
    }

    public void RecalculateTextureSize()
    {
        RenderTextureCamera.RecalculateTextureSize();
    }

    public void ResetContent()
    {
        foreach (GameObject content in Contents)
        {
            content.SetActive(false);
        }
    }

    public void SetEndedLetter()
    {
	//	for(int i=0; i < Smile_particle.Length; i++)
		//{
		//	Instantiate (Smile_particle[i],Smile_particle[i].transform.position, Smile_particle[i].transform.rotation);
		//}

		ReloadLetter.GetComponent<Reload_letter> ().OnClick ();
    //   CareTakerImage.Memento.Letter.GetComponent<Letter>().PreparationResources();
        Debug.Log("Content="+CareTakerImage.Memento.Content.name);
       
        ChangedSate(Mark.ar_camera);
       // CareTakerImage.Memento.Content.SetActive(true);
        CareTakerImage.Memento.CheckLetter = true;
    }
	public void SetEndPart1P()
	{
		DataLevel.Instance.Hand.GetComponent<Animator> ().enabled = false;
		DataLevel.Instance.Hand2.GetComponent<Animator> ().enabled = true;
		DataLevel.Instance.Hand2.SetActive (true);
		DataLevel.Instance.Hand.SetActive (false);


	}
	}


