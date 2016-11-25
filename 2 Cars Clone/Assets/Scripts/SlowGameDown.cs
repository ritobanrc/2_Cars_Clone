using UnityEngine;
using System.Collections;

public class SlowGameDown : MonoBehaviour
{
    public float speed;
	// Use this for initialization
	void Start ()
    {
        Time.timeScale = speed;
        Time.fixedDeltaTime = 0.01f;
        Time.fixedDeltaTime = speed * 0.01f;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
