using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetHighScoreValue : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("highscore", 0).ToString();
	}
	
}
