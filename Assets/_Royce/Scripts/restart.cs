using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void resetPlayerPref()
    {
        PlayerPrefs.SetInt("CurScene", 1);
        PlayerPrefs.SetInt("Choice1", 0);
        PlayerPrefs.SetInt("Choice2", 0);
        PlayerPrefs.SetInt("Choice3", 0);
        PlayerPrefs.SetInt("Choice4", 0);
        PlayerPrefs.SetInt("Choice5", 0);

        SceneManager.LoadScene("MainMenu");
    }
}
