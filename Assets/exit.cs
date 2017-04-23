using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public int dark_light; //dark = 0, light = 1
    public int scene;

    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerPrefs.SetInt("Choice"+scene, dark_light);
        if(scene == 2)
        {
            if(dark_light == 1)
            {
                PlayerPrefs.SetInt("gf", 1);
                PlayerPrefs.SetInt("CurScene", scene + 1);
                PlayerPrefs.Save();

                Application.LoadLevel(scene + 1);
            }
            else
            {
                PlayerPrefs.SetInt("gf", 0);
                PlayerPrefs.SetInt("CurScene", scene + 2);
                PlayerPrefs.Save();

                Application.LoadLevel(scene + 2);
            }
        }
        else
        {
            PlayerPrefs.SetInt("CurScene", scene + 1);
            PlayerPrefs.Save();

            Application.LoadLevel(scene + 1);
        }
    }
}
