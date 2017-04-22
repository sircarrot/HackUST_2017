using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public int dark_light; //dark = 0, light = 1
    public int scene;

    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerPrefs.SetInt("Scene"+scene, dark_light);
        PlayerPrefs.Save();
        Application.LoadLevel(scene + 1);
    }
}
