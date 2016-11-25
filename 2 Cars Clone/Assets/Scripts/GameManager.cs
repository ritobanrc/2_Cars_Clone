using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public AudioSource SFXAudio;
    public AudioSource backgroundAudio;
    public static GameManager instance;
    public int Score;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        DontDestroyOnLoad(this);

        MainSceneStart();
    }

    public void MainSceneStart()
    {
        Score = 0;
        backgroundAudio.pitch = Random.value * 2f;
    }

    public void GameOver(Transform cameraZoomPoint, float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = timeScale * 0.02f;
        StartCoroutine(ZoomCameraToPoint(cameraZoomPoint, 2f * timeScale));
    }

    private IEnumerator ZoomCameraToPoint(Transform cameraZoomPoint, float time)
    {
        float startTime = Time.time;
        while (Time.time - startTime < time)
        {
            if (Camera.main.transform == null || cameraZoomPoint == null)
            {
                SceneManager.LoadScene("GameOver");
                yield break;
            }
            Camera.main.transform.position = Vector3.Lerp(
                Camera.main.transform.position,
                new Vector3(cameraZoomPoint.position.x, cameraZoomPoint.position.y, Camera.main.transform.position.z),
                10 * Time.deltaTime
                );
            Camera.main.orthographicSize = Mathf.Lerp(
                Camera.main.orthographicSize,
                0.5f,
                1 * Time.deltaTime
                );
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 0.75f;
        Time.fixedDeltaTime = 0.75f * 0.02f;
        SceneManager.LoadScene("GameOver");
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        if(Score > highScore)
        {
            PlayerPrefs.SetInt("highscore", Score);
        }
        backgroundAudio.pitch /= 2;
    }
}
