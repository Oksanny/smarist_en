using System;
using UnityEngine;
using System.Collections;

public class NavMeshLetter : MonoBehaviour {
    public GameObject target;
    public Transform target_start;
    public GameObject teleport;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;
    private bool CheckGo;
    private int StateAnimator;

	// Use this for initialization
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        teleport.SetActive(false);
    }
    void OnEnable()
    {
        if (StateAnimator==1)
        {
            Debug.Log("Idle_1");
			animator.Play ("Idle");
           // animator.SetTrigger("Idle"); 
        }
        if (StateAnimator == 2)
        {
           // animator.SetTrigger("Walk");
			animator.Play ("Walk");
        }
    }
	void Start ()
	{
	    CheckGo = false;
       
	}

    public void StartGo()
    {
        Debug.Log("StartGo");
        CheckGo = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.enabled = true;
		animator.Play ("Walk");
       // animator.SetTrigger("Walk");
        StateAnimator = 2;
    }
    public void ReStartGo()
    {
        Debug.Log("ReStartGo");
        CheckGo = false;
        teleport.SetActive(false);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = false;
        animator = GetComponent<Animator>();
		animator.Play ("Idle");
        //animator.SetTrigger("Idle");
        StateAnimator = 1;
    }
	// Update is called once per frame
	void Update () {
       MovePlayer();
	}

    void MovePlayer()
    {
        if (CheckGo)
        {
            agent.SetDestination(target.transform.position);
			animator.Play ("Walk");
          //  animator.SetTrigger("Walk");
        }
        else
        {
            animator = GetComponent<Animator>();
			animator.Play ("Idle");
           // animator.SetTrigger("Idle");
        }
        
    }
    void OnTriggerEnter(Collider other)
    {

        if ( String.Compare(other.name,target.name,true)==0)
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            animator = GetComponent<Animator>();
            Debug.Log("Collision=" + other.name);
           agent.enabled = false;
            CheckGo = false;
            target.GetComponent<BoxCollider>().enabled = false;
            teleport.SetActive(true);
			StateAnimator = 1;
            //animator.SetTrigger("Idle");
			animator.Play ("Idle");
            
        }
    }
}
