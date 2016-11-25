using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour
{

	public void Replay(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
