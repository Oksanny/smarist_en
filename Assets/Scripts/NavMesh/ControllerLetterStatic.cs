using UnityEngine;
using System.Collections;

public class ControllerLetterStatic : MonoBehaviour {
    private Animator animator;
    private bool CheckGo;

    // Use this for initialization
    void Awake()
    {

        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        if (DataLevel.Instance.CurrentState == Mark.ar_camera)
        {
			animator.Play("Idle");
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        if (DataLevel.Instance.CurrentState == Mark.ar_camera)
        {
			//animator.Play ("Jump");
			StartCoroutine("StartPresentLetter");
			AudioSource clip = gameObject.GetComponent<AudioSource> ();
			clip.Play ();
        }
       
    }
	IEnumerator StartPresentLetter()
	{
		//  Debug.Log("WaitForSeconds_2");
		yield return new WaitForSeconds(3f);
		if (DataLevel.Instance.CurrentState == Mark.ar_camera)
		{
			//animator.Play ("Idle");
			//  animator.SetTrigger("Present");
		}

	}
}
