using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenFadeout : MonoBehaviour {

    public Image ImgFade;
    public float fadeOutTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(Fadeout());
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator Fadeout()
    {

            ImgFade.canvasRenderer.SetAlpha(1f);
            ImgFade.gameObject.SetActive(true);
            ImgFade.CrossFadeAlpha(0f, fadeOutTime, false);
            yield return new WaitForSeconds(fadeOutTime);
    }
}
