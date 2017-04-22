﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {

    public Text StartTxt;
    public float fadeInTime;
    public float stayTime;
    public float fadeOutTime;

    public bool startblink;
    // Use this for initialization
    void Start()
    {
        startblink = true;
    }

    void Update()
    {

        StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        if (startblink)
        {
            startblink = false;

            StartTxt.canvasRenderer.SetAlpha(0f);
            StartTxt.gameObject.SetActive(true);
            StartTxt.CrossFadeAlpha(1f, fadeInTime, false);
            yield return new WaitForSeconds(stayTime);
            StartTxt.CrossFadeAlpha(0f, fadeOutTime, false);
            yield return new WaitForSeconds(stayTime);

            startblink = true;
        }
    }
}
