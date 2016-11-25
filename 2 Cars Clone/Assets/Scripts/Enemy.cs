using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public static AudioClip onCollisionClip;

    void Start()
    {
        onCollisionClip = Resources.Load<AudioClip>("AudioClips/CarExplosionSoundEffect");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.SFXAudio.Stop();
            GameManager.instance.SFXAudio.pitch = Random.value * 4 - 2;
            GameManager.instance.SFXAudio.clip = onCollisionClip;
            GameManager.instance.SFXAudio.Play(); 
            GameManager.instance.GameOver(transform, 0.2f);
        }
    }

}
