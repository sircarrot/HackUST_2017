using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneMaster : MonoBehaviour {

    public int choice_1;
    public int choice_2;
    public int choice_3;
    public int choice_4;
    public int choice_5;
    public int cur_scene;

    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("CurScene"))
        {
            // If first time playing, initialise the following variables
            PlayerPrefs.SetInt("CurScene", 1);
            PlayerPrefs.SetInt("Choice1", 0);
            PlayerPrefs.SetInt("Choice1", 0);
            PlayerPrefs.SetInt("Choice1", 0);
            PlayerPrefs.SetInt("Choice1", 0);
            PlayerPrefs.SetInt("Choice1", 0);
        }
        cur_scene = PlayerPrefs.GetInt("CurScene");
        choice_1 = PlayerPrefs.GetInt("Choice1");
        choice_2 = PlayerPrefs.GetInt("Choice2");
        choice_3 = PlayerPrefs.GetInt("Choice3");
        choice_4 = PlayerPrefs.GetInt("Choice4");
        choice_5 = PlayerPrefs.GetInt("Choice5");
    }
	
	// Update is called once per frame

     public void selectScene()
    {
        if(cur_scene == 1)
        {
            SceneManager.LoadScene("Stage1");
        }
        //Further scenes
    }
}
