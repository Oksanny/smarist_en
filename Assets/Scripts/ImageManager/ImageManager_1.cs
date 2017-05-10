using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageManager_1 : MonoBehaviour, ImageManagerInterface
{
    public Sprite Letters_Gray;
    public Sprite Letters_Red;
    public GameObject[] Score;
    public GameObject Content;
    public GameObject ContentForPhoto;
    public GameObject PineappleDynamic;
    public GameObject PineappleStatic;
    public GameObject Island;
    public GameObject[] Letters;
    public GameObject LetterStatic;
    public GameObject[] TargetsLetters;
    public Transform StartPositionPineapple_Static;
    public Transform StartPositionPineapple_Dynamic;
    public Transform StartPositionLetter_Static;
    public Transform StartPositionLetters_Dynamic;
    public int ScoreLetters;
    public SimpleSelectTransform SimpleSelect;
    void Awake()
    {
        SetStart_StaticState();
        SetActiveContent(false);
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore()
    {
        ScoreLetters++;
        if (ScoreLetters<=Score.Length)
        {
            for (int i = 0; i < ScoreLetters; i++)
            {
                Score[i].GetComponent<UnityEngine.UI.Image>().sprite = Letters_Red;
               
            }
        }
    }
    public void SetStart_StaticState()
    {
        DataLevel.Instance.MementoStateStaticGamePlay();
        ContentForPhoto.transform.parent = Content.transform;
        ContentForPhoto.SetActive(false);
        for (int i = 0; i < TargetsLetters.Length; i++)
        {
            TargetsLetters[i].SetActive(false);
        }
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].SetActive(false);

        }
        // Letters[0].SetActive(true);
        // Letters[0].GetComponent<NavMeshLetter>().enabled = false;
        //Letters[0].transform.position = StartPositionLetter_Static.position;
        //Letters[0].GetComponent<Animator>().SetTrigger("Idle");
        LetterStatic.SetActive(true);

        LetterStatic.transform.position = new Vector3(StartPositionLetter_Static.position.x, StartPositionLetter_Static.position.y, StartPositionLetter_Static.position.z);
        LetterStatic.transform.localScale = new Vector3(StartPositionLetter_Static.localScale.x, StartPositionLetter_Static.localScale.y, StartPositionLetter_Static.localScale.z);
        LetterStatic.transform.LookAt(StartPositionLetter_Static); 
        PineappleStatic.SetActive(true);
        PineappleDynamic.SetActive(false);
        Island.SetActive(false);
        PineappleStatic.transform.position = new Vector3(StartPositionPineapple_Static.position.x, StartPositionPineapple_Static.position.y, StartPositionPineapple_Static.position.z);
        PineappleStatic.transform.localScale = new Vector3(StartPositionPineapple_Static.localScale.x, StartPositionPineapple_Static.localScale.y, StartPositionPineapple_Static.localScale.z);
        PineappleStatic.transform.LookAt(StartPositionPineapple_Static); 
        //Pineapple.GetComponent<Animator>().SetTrigger("Idle");
    }

    public void SetStart_DynamicState()
    {
        ScoreLetters = 0;
        ContentForPhoto.SetActive(false);
        
        for (int i = 0; i < Score.Length; i++)
        {
            Score[i].GetComponent<UnityEngine.UI.Image>().sprite = Letters_Gray;
            Score[i].SetActive(false);
        }
        DataLevel.Instance.MementoStateDynamicGamePlay();
        DataLevel.Instance.MementoStateGoGamePlay(false);
        LetterStatic.SetActive(false);
        Island.SetActive(true);
        for (int i = 0; i < TargetsLetters.Length; i++)
        {
            TargetsLetters[i].SetActive(true);
            TargetsLetters[i].GetComponent<BoxCollider>().enabled = true;
        }
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].GetComponent<Animator>().enabled = false;
            Letters[i].SetActive(false);

        }
        for (int i = 0; i < Letters.Length; i++)
        {
            Letters[i].SetActive(true);
            // Letters[i].GetComponent<NavMeshLetter>().e;
            Letters[i].transform.position = StartPositionLetters_Dynamic.position;
            Letters[i].GetComponent<Animator>().enabled = true;
            Letters[i].GetComponent<NavMeshLetter>().ReStartGo();
        }
        PineappleDynamic.SetActive(true);
        PineappleDynamic.transform.position = StartPositionPineapple_Dynamic.position;
        PineappleDynamic.GetComponent<NuMesh>().ReStartGo();
        PineappleStatic.SetActive(false);
        //Pineapple.GetComponent<Animator>().SetTrigger("Idle");
        // DataLevel.Instance.ButtonPlayGame.SetActive(true);
    }

    public void SetActive_StaticPart(bool state)
    {

    }

    public void SetActive_DynamicPart(bool state)
    {

    }

    public void Play_StaticPart()
    {

    }

    public void Play_DynamicPart()
    {

        for (int i = 0; i < Letters.Length; i++)
        {

            Letters[i].GetComponent<NavMeshLetter>().StartGo();

        }
        PineappleDynamic.GetComponent<NuMesh>().StartGo();
        DataLevel.Instance.ButtonPlayGame.SetActive(false);
        DataLevel.Instance.MementoStateGoGamePlay(true);
        for (int i = 0; i < Score.Length; i++)
        {
            Score[i].SetActive(true);
        }
    }

    public void SetActiveContent(bool state)
    {
        if (state)
        {
            Content.SetActive(true);
        }
        else
        {
            Content.SetActive(false);
        }
    }

    public void GoToPhotoState()
    {

        ContentForPhoto.transform.parent = SimpleSelect.transform.GetChild(0);
        ContentForPhoto.SetActive(true);
        ContentForPhoto.transform.localPosition=new Vector3(0,-4f,12f);
       // ContentForPhoto.transform.localPosition = new Vector3(PositionPhoto.transform.localPosition.x, PositionPhoto.transform.localPosition.y, PositionPhoto.transform.localPosition.z);
        ContentForPhoto.transform.localScale = new Vector3(PineappleStatic.transform.localScale.x, PineappleStatic.transform.localScale.y, PineappleStatic.transform.localScale.z);
        ContentForPhoto.transform.localEulerAngles=new Vector3(0,180f,0);
        SimpleSelect.SelectedGameObject = ContentForPhoto;
       PineappleStatic.SetActive(false);
        LetterStatic.SetActive(false);
    }
}
