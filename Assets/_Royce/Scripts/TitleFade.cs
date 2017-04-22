using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TitleFade : MonoBehaviour {

    public Text TitleTxt;
    public float fadeInTime;
    public float stayTime;

    public bool startfade;
    // Use this for initialization
    void Start()
    {
        startfade = true;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        if (startfade)
        {
            startfade = false;

            TitleTxt.canvasRenderer.SetAlpha(0f);
            TitleTxt.gameObject.SetActive(true);
            TitleTxt.CrossFadeAlpha(1f, fadeInTime, false);
            yield return new WaitForSeconds(stayTime);
        }
    }
}
