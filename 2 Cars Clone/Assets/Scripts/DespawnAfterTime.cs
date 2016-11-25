using UnityEngine;
using System.Collections;
using System;

public class DespawnAfterTime : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Despawn());
	}

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3);
        SimplePool.Despawn(gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
