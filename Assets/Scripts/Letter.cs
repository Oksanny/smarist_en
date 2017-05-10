using UnityEngine;
using System.Collections;
public enum StatePartLine
{
    start,
    end,
    idle,
    lost
}
public class Letter :MonoBehaviour
{
    public GameObject[] LetterParts;
    public StatePartLine StatePart;
    public int count;
    public LetterPart CurrentLetterPart;
    void OnEnable()
    {
        PreparationResources();
        SetIdle();
    }
    // Use this for initialization
    void Start()
    {
        PreparationResources();
        SetIdle();
       
    }

    // Update is called once per frame
    void Update()
    {
		//if (Input.GetButton("F"))
		//	SetStateEnd ();
    }

    public void PreparationResources()
    {
        count = 0;
        for (int i = 0; i < LetterParts.Length; i++)
        {
            LetterParts[i].SetActive(true);
        }
       
        for (int i = 0; i < LetterParts.Length; i++)
        {
            for (int j = 0; j < LetterParts[i].GetComponent<LetterPart>().elemenets.Length; j++)
            {
                
                LetterParts[i].GetComponent<LetterPart>().elemenets[j].GetComponent<Element>().ControllerLetter=this;
                if (LetterParts[i].GetComponent<LetterPart>().elemenets[j].Status == StatusElement.out_line)
                {
                    LetterParts[i].GetComponent<LetterPart>().elemenets[j].GetComponent<Collider>().enabled = false;
                }
                if (LetterParts[i].GetComponent<LetterPart>().elemenets[j].Status == StatusElement.end ||
                    LetterParts[i].GetComponent<LetterPart>().elemenets[j].Status == StatusElement.start ||
                    LetterParts[i].GetComponent<LetterPart>().elemenets[j].Status == StatusElement.none)
                {
                    LetterParts[i].GetComponent<LetterPart>().elemenets[j].Number = j;
                    Debug.Log("Part=" + LetterParts[i].GetComponent<LetterPart>().elemenets[j].gameObject.name);
                    LetterParts[i].GetComponent<LetterPart>().elemenets[j].GetComponent<Element>().colorPlane.material.color = Color.white;
                    LetterParts[i].GetComponent<LetterPart>().elemenets[j].GetComponent<Collider>().enabled = true;

                }

            }

        }
        for (int i = 0; i < LetterParts.Length; i++)
        {
            for (int j = 0; j < LetterParts[i].GetComponent<LetterPart>().tutorial.Length; j++)
            {
                LetterParts[i].GetComponent<LetterPart>().tutorial[j].SetActive(true);
            }
        }
        CurrentLetterPart = LetterParts[0].GetComponent<LetterPart>();
        for (int i = 1; i < LetterParts.Length; i++)
        {
            LetterParts[i].SetActive(false);
        }
    }
    public void SetIdle()
    {
        StatePart = StatePartLine.idle;
        for (int i = 0; i <CurrentLetterPart.elemenets.Length; i++)
        {
            if (CurrentLetterPart.elemenets[i].Status == StatusElement.out_line)
            {

                CurrentLetterPart.elemenets[i].GetComponent<Collider>().enabled = false;
            }
            

            if (CurrentLetterPart.elemenets[i].Status == StatusElement.end |
                CurrentLetterPart.elemenets[i].Status == StatusElement.start ||
                CurrentLetterPart.elemenets[i].Status == StatusElement.none)
            {
                CurrentLetterPart.elemenets[i].colorPlane.material.color = Color.white;
                CurrentLetterPart.elemenets[i].GetComponent<Collider>().enabled = true;
                
            } 
           
        }
        for (int i = 0; i < CurrentLetterPart.tutorial.Length; i++)
        {
            CurrentLetterPart.tutorial[i].SetActive(true);
        }

    }

    public void SetStart()
    {
        StatePart = StatePartLine.start;
        for (int i = 0; i < CurrentLetterPart.elemenets.Length; i++)
        {

            if (CurrentLetterPart.elemenets[i].Status==StatusElement.out_line) CurrentLetterPart.elemenets[i].GetComponent<Collider>().enabled = true;
            
        }
        for (int i = 0; i < CurrentLetterPart.tutorial.Length; i++)
        {
            CurrentLetterPart.tutorial[i].SetActive(false);
        }
    }
    public void StartGo(int number)
    {
        if (StatePart == StatePartLine.start)
        {
            for (int i = 0; i < CurrentLetterPart.elemenets.Length; i++)
            {
                CurrentLetterPart.elemenets[i].colorPlane.material.color = Color.white;
                if (i <= number)
                    CurrentLetterPart.elemenets[i].colorPlane.material.color = Color.green;
            }
        }

    }

    public void SetStateEnd()
    {
        if (StatePart == StatePartLine.start)
        {
            StatePart = StatePartLine.end;
            for (int i = 0; i < CurrentLetterPart.elemenets.Length; i++)
            {
                
                CurrentLetterPart.elemenets[i].GetComponent<Collider>().enabled = false;
            }
            count++;
            if (count<LetterParts.Length)
            {
                LetterParts[count].SetActive(true);
                CurrentLetterPart = LetterParts[count].GetComponent<LetterPart>();
               // SetIdle();
            }
            else
            {
                DataLevel.Instance.GetMementoImageTarget().CheckLetter = true;
                DataLevel.Instance.ButtonNext.SetActive(true);
            }
        }

    }

    void OnMouseOver()
    {
        if (StatePart == StatePartLine.start)
        {
            Debug.Log("OnMouseOver=" + gameObject.name);
            SetIdle();
        }



    }
    void OnMouseUp()
    {
        Debug.Log(gameObject.name);
        if (StatePart == StatePartLine.start)
        {
            Debug.Log("OnMouseUp=" + gameObject.name);
            SetIdle();
        }

    }
}
