using UnityEngine;
using System.Collections.Generic;

public class Pickup : MonoBehaviour
{
    HashSet<GameObject> collidedObjects;
    AudioClip collectedClip;
    void Start()
    {
        collectedClip = Resources.Load<AudioClip>("AudioClips/PickupSoundEffect");
    }

    void OnEnable()
    {
        collidedObjects = new HashSet<GameObject>();
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.transform.tag=="Player" && !collidedObjects.Contains(col.gameObject))
        {
            GameManager.instance.Score++;
            collidedObjects.Add(col.gameObject);
            gameObject.SetActive(false);
            GameManager.instance.SFXAudio.Stop();
            GameManager.instance.SFXAudio.pitch = Random.value * 4 - 2;
            GameManager.instance.SFXAudio.clip = collectedClip;
            GameManager.instance.SFXAudio.Play();
        }
    }
}
