using UnityEngine;
using System.Collections;

public class AnimLister : MonoBehaviour
{
    public AudioSource Sound;
	// Use this for initialization
	void Start ()
	{
	    Sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    
	}

    void LettereASound(float value=1f)
    {
        Sound.Play();
        Debug.Log("Jump"+gameObject.name);
    }
}
