using UnityEngine;
using System.Collections;

public class CameraMoveForward : MonoBehaviour
{
    Transform target;
    Vector3 offset;
	// Use this for initialization
	void Start ()
    {
        target = FindObjectOfType<CarMovement>().transform;
        
        offset = transform.position - target.position;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(transform.position.x, offset.y + target.position.y, transform.position.z);
    }


}
