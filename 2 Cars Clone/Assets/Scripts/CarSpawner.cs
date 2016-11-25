using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    public Transform redStart;
    public Transform blueStart;
    public GameObject carPrefab;
    public Sprite redCarSprite;
    public Sprite blueCarSprite;

    private GameObject redCar;
    private GameObject blueCar;

    void Awake()
    {
        redCar = Instantiate(carPrefab, redStart.position, redStart.rotation) as GameObject;
        redCar.name = "Red Car - Left";
        blueCar = Instantiate(carPrefab, blueStart.position, blueStart.rotation) as GameObject;
        blueCar.name = "Blue Car - Right";
        CarMovement redMovement = redCar.GetComponent<CarMovement>();
        redMovement.axisSuffix = "Left";
        redMovement.otherCar = blueCar.GetComponent<Rigidbody2D>();
        redMovement.lane = 0;
        redMovement.negatePositions = -1;
        CarMovement blueMovement = blueCar.GetComponent<CarMovement>();
        blueMovement.axisSuffix = "Right";
        blueMovement.otherCar = redCar.GetComponent<Rigidbody2D>();
        blueMovement.lane = 0;
        blueMovement.negatePositions = 1;

        GameObject redCarGraphic = new GameObject();
        redCarGraphic.AddComponent<SpriteRenderer>().sprite = redCarSprite;
        redCarGraphic.transform.SetParent(redCar.transform, false);
        redCarGraphic.name = "RedCarGraphic";

        GameObject blueCarGraphics = new GameObject();
        blueCarGraphics.AddComponent<SpriteRenderer>().sprite = blueCarSprite;
        blueCarGraphics.transform.SetParent(blueCar.transform, false);
    }
}
