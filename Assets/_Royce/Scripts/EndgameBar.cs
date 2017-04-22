using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameBar : MonoBehaviour {

    public float same;
    public float total;
    public GameObject gauge;
    public GameObject totalbar;

    public int frames;
    float prct;
    float width;
    bool ani = false;
    // Use this for initialization

    void Start()
    {
        //Exp bar masking
        prct = same / total;

        width = totalbar.GetComponent<RectTransform>().rect.width;
        StartCoroutine(BarAnimation());
    }

    IEnumerator BarAnimation()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        float updatewidth = 0;
        for (int i = 0; i < frames; i++)
        {
            // Move panels according to direction
            updatewidth += width * prct / frames;
            rect.sizeDelta = new Vector2 (updatewidth, rect.sizeDelta.y);
            //Debug.Log(width);
            yield return new WaitForEndOfFrame();

        }

    }
}
