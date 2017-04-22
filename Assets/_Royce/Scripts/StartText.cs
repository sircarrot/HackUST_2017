using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour {

    public GameObject SceneMaster;
    public Image ClickBox;
    public Text StartTxt;
    public float waitTitleTime;
    public float fadeInTime;
    public float stayTime;
    public float fadeOutTime;

    public bool startblink;
    public bool clickbool = false;
    public AudioClip clickSound;
    public AudioSource bg;
    // Use this for initialization
    void Start()
    {
        startblink = false;
        StartCoroutine(waitTitle());
    }

    void Update()
    {
        StartCoroutine(Blink());
        if(clickbool)
        {
            bg.volume -= 0.1f * Time.deltaTime;
        }
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
    IEnumerator waitTitle()
    {
        startblink = false;
        ClickBox.canvasRenderer.SetAlpha(0f);
        StartTxt.canvasRenderer.SetAlpha(0f);
        yield return new WaitForSeconds(waitTitleTime);
        startblink = true;
    }

    public void clickMenu()
    {
        if (!clickbool)
        {
            clickbool = true;
            startblink = false;
            StartCoroutine(Flash());
            gameObject.GetComponent<AudioSource>().PlayOneShot(clickSound);
        }
    }
    IEnumerator Flash()
    {
        yield return new WaitForSeconds(1);
        ClickBox.CrossFadeAlpha(1f, 3, false);
        yield return new WaitForSeconds(3);
        SceneMaster.GetComponent<sceneMaster>().selectScene();
    }

}
