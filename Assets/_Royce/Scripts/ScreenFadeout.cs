using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScreenFadeout : MonoBehaviour {

    public int prevscene;
    public Image ImgFade;
    public float fadeOutTime;

	// Use this for initialization
	void Start () {
        if (prevscene != 0)
        {
            if (PlayerPrefs.GetInt("Choice" + prevscene) == 0)
            {
                ImgFade.color = new Color32(0, 0, 0, 255);
            }
            else
            {
                ImgFade.color = new Color32(255, 255, 255, 255);
            }
        }



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
            Destroy(this.gameObject);
    }
}
