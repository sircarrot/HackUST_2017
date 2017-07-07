using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

    public Image fadeBox;
    public float fadetime;
    public AudioClip clickSound;

    // Use this for initialization
    void Start () {
        fadeBox.canvasRenderer.SetAlpha(0f);
    }



    public void resetPlayerPref()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(clickSound);

        PlayerPrefs.SetInt("CurScene", 1);
        PlayerPrefs.SetInt("Choice1", 0);
        PlayerPrefs.SetInt("Choice2", 0);
        PlayerPrefs.SetInt("Choice3", 0);
        PlayerPrefs.SetInt("Choice4", 0);
        PlayerPrefs.SetInt("Choice5", 0);

        StartCoroutine(fadeToMain());
    }

    IEnumerator fadeToMain()
    {
        yield return new WaitForSeconds(1);
        fadeBox.gameObject.SetActive(true);
        fadeBox.CrossFadeAlpha(1f, fadetime, false);
        yield return new WaitForSeconds(fadetime);
        SceneManager.LoadScene("MainMenu");
    }

}
