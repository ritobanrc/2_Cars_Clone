using UnityEngine;
using System.Collections;
using System;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] disableOnPause;

    public Transform pauseMenu;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf); 
        foreach(GameObject go in disableOnPause)
        {
            go.SetActive(!go.activeSelf);
        }
        CarMovement[] cars = FindObjectsOfType<CarMovement>();
        foreach(CarMovement car in cars)
        {
            car.enabled = !car.enabled;
            Rigidbody2D rb = car.GetComponent<Rigidbody2D>();
            rb.isKinematic = !rb.isKinematic;
            IncreaseMovementSpeed ims = car.GetComponent<IncreaseMovementSpeed>();
            ims.enabled = !ims.enabled;
        }
    }
}
