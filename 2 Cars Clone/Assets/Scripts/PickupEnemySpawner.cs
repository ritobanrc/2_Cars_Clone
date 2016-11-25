using UnityEngine;

public class PickupEnemySpawner : MonoBehaviour
{
    public float leftLane;
    public float rightLane;

    public GameObject enemyPrefab;
    public GameObject pickupPrefab;
    public float initialDelay;
    public Vector2 timeBetweenSpawns;

    private float timeBetweenSpawnsTimer;
    private static System.Random rand;
    // Use this for initialization
    void Start()
    {
        timeBetweenSpawnsTimer = initialDelay;
        if(rand == null)    
            rand = new System.Random();
        GameManager.instance.MainSceneStart();
    }

    void Update()
    {
        timeBetweenSpawnsTimer -= Time.deltaTime;
        if (timeBetweenSpawnsTimer <= 0)
        {
            SpawnEnemyPickup();
            timeBetweenSpawnsTimer = ((float)rand.NextDouble()) * (timeBetweenSpawns.y - timeBetweenSpawns.x) + timeBetweenSpawns.x;
        }
    }

    void SpawnEnemyPickup()
    {
        GameObject prefab = (Random.Range(0, 2) == 0) ? enemyPrefab : pickupPrefab;
        float xPos = (Random.Range(0, 2) == 0) ? leftLane : rightLane;
        Vector3 pos = new Vector3(xPos, Camera.main.ScreenToWorldPoint(new Vector3(xPos, Screen.height)).y, 0);
        GameObject obj = SimplePool.Spawn(prefab, pos, Quaternion.identity) as GameObject;
        obj.transform.SetParent(transform);
    }
}
