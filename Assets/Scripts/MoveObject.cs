using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour {

    public Transform target;
    public Transform startPosition;
    public float speed;
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (Mathf.Abs(transform.position.x-target.position.x)<0.001f)
        {
            transform.position =new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z);
        }
    }
}
