using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenFadeIn : MonoBehaviour
{

    public int scene;
    public Image ImgFade;
    public float fadeInTime;

    public bool bgbool = false;
    public AudioSource bg;

    void Start()
    {
        ImgFade.canvasRenderer.SetAlpha(0f);
    }

    void Update()
    {
        if (bgbool)
        {
            bg.volume -= 0.1f * Time.deltaTime;
        }
    }


    // Use this for initialization
    public void CallFadeIn(int loadscene)
    {
        if(PlayerPrefs.GetInt("Choice"+scene) == 0)
        {
            ImgFade.color = new Color32(0, 0, 0, 255);
        }
        else
        {
            ImgFade.color = new Color32(255, 255, 255, 255);
        }

        bgbool = true;
        StartCoroutine(Fadein(loadscene));
    }

    IEnumerator Fadein(int loadscene)
    {
        ImgFade.canvasRenderer.SetAlpha(0f);
        ImgFade.gameObject.SetActive(true);
        ImgFade.CrossFadeAlpha(1f, fadeInTime, false);
        yield return new WaitForSeconds(fadeInTime);
        Destroy(this.gameObject);
        Application.LoadLevel(loadscene);
    }
}
