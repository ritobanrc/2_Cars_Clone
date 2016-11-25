using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CarMovement))]
public class IncreaseMovementSpeed : MonoBehaviour
{
    //The value Time.timeSinceLevelLoad will be used in the form speed = b(time) + b
    public float m;
    public float b;

    CarMovement movement;
	// Use this for initialization
	void Start ()
    {
        movement = GetComponent<CarMovement>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        movement.speed = m * Time.timeSinceLevelLoad + b;
	}
}
