using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class NuMesh : MonoBehaviour
{
    public ParticleSystem Particle;
    public Camera camera;
    public Transform target;
    public Transform target_empty;
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;
    public  string currentCollider;
    public bool CheckGo;
    private bool CheckNavMesh;
    private int StateAnimator;
	private bool FindLetter;
    void Awake()
    {
		FindLetter = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    void OnEnable()
    {
        if (StateAnimator == 1)
        {
            Debug.Log("Idle_1");
			animator.Play ("Idle");
           // animator.SetTrigger("Idle");
        }
        if (StateAnimator == 2)
        {
			animator.Play ("Walk");
           // animator.SetTrigger("Walk");
        }
    }
    void Start()
    {
        CheckGo = false;
        CheckNavMesh = false;
        currentCollider = "1111";

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
        CheckNavMesh = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.enabled = false;
        animator = GetComponent<Animator>();
		animator.Play ("Idle");
       // animator.SetTrigger("Idle");
        StateAnimator = 1;
    }
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update ()
	{
	    MovePlayer();
        if (CheckGo&&Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray =camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name.Contains("Letter") )
                {
                    agent.enabled = true;
                    target = hit.transform;
                    
                    currentCollider = hit.transform.name;
                    CheckNavMesh = true;
                    Debug.Log("Selected= " + hit.transform.name);
                }
                else
                {
                    currentCollider = target_empty.name;
                    agent.enabled = true;
                    target_empty.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                    target_empty.GetComponent<BoxCollider>().enabled = true;
                    target = target_empty;
                    CheckNavMesh = true;
                    Debug.Log("Selected= " + hit.transform.name); 
                }
                
                
                
            }
        }
	    
	    
	   //if (Vector3.Distance(transform.position,target.transform.position)<3f)
	   //{
	   //    animator.SetTrigger("Idle");
	   //}
	   //else
	   //{
       //    animator.SetTrigger("Walk");
	   //}
       // Debug.Log(Vector3.Distance(transform.position, target.transform.position));
	}
    void MovePlayer()
    {
        if (CheckNavMesh)
        {
            agent.SetDestination(target.transform.position);
            //animator.SetTrigger("Walk");
			animator.Play ("Walk");
        }
        else
        {
			if(FindLetter){
			Debug.Log ("Pineapple_idle");
            animator = GetComponent<Animator>();
			animator.Play ("Idle");
          //  animator.SetTrigger("Idle");
			}
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Letter"))
        {
            other.gameObject.SetActive(false);
            DataLevel.Instance.ImageManagerInterface.SetScore();
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            animator = GetComponent<Animator>();
            Debug.Log("Collision=" + other.name);
            agent.enabled = false;
            CheckNavMesh = false;
            agent.enabled = false;
            GameObject tg=new GameObject();
            tg.transform.position=new Vector3(DataLevel.Instance.ARCamera.transform.position.x,gameObject.transform.position.y,DataLevel.Instance.ARCamera.transform.position.z);
            gameObject.transform.LookAt(tg.transform);
            Destroy(tg);
           // Particle.Play();
            //transform.LookAt(camera.GetComponent<Transform>());
			FindLetter=false;
			Debug.Log("FindLetter work");
			animator.Play("Find_Letter");
          //  animator.SetTrigger("Find_Letter");
            StateAnimator = 1;
            return;
        }
        
        if (other.name.Contains(currentCollider) )
        {
            target_empty.GetComponent<BoxCollider>().enabled = false;
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            animator = GetComponent<Animator>();
            Debug.Log("Collision=" + other.name);
            agent.enabled = false;
            CheckNavMesh = false;
            agent.enabled=false;
            GameObject tg = new GameObject();
            tg.transform.position = new Vector3(DataLevel.Instance.ARCamera.transform.position.x, gameObject.transform.position.y, DataLevel.Instance.ARCamera.transform.position.z);
            gameObject.transform.LookAt(tg.transform);
            Destroy(tg);
           // transform.LookAt(camera.GetComponent<Transform>());
			animator.Play ("Lost_Letter");
           // animator.SetTrigger("Lost_Letter");
            StateAnimator = 1;
        }
    }
}
