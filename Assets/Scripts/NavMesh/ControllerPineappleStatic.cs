using UnityEngine;
using System.Collections;

public class ControllerPineappleStatic : MonoBehaviour {
    
    private Animator animator;
    private bool CheckGo;
    
    // Use this for initialization
    void Awake()
    {
       
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
       // Debug.Log("WaitForSeconds_1");
        StartCoroutine("StartPresent");
    }
	// Use this for initialization
	void Start () {
        StartCoroutine("StartPresent");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        if (DataLevel.Instance.CurrentState==Mark.ar_camera)
        {
			Debug.Log("play sound");
			animator.Play ("Win");
			StartCoroutine("StartPresent");
			AudioSource clip = gameObject.GetComponent<AudioSource> ();
			clip.Play ();
        }
       
    }

    IEnumerator StartPresent()
    {
      //  Debug.Log("WaitForSeconds_2");
        yield return new WaitForSeconds(1f);
        if (DataLevel.Instance.CurrentState == Mark.ar_camera)
        {
			animator.Play ("Idle");
          //  animator.SetTrigger("Present");
        }

    }
}
