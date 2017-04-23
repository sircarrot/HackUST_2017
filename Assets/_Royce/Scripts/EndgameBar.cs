using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndgameBar : MonoBehaviour {

    public CustomDatabase GameMaster;
    public GameObject Parent;
    public Text PrctText;
    public int num;

    public float same;
    public float total;
    public GameObject gauge;
    public GameObject totalbar;

    public int frames;
    float prct;
    float width;
    bool ani = false;
    // Use this for initialization

    public void callingFunk()
    {
        if (num == 3 && GameMaster.gf == false)
        {
            Parent.gameObject.SetActive(false);
        }
        if (num == 4 && GameMaster.gf == true)
        {
            Parent.gameObject.SetActive(false);
        }

        string placetext = "";
        if (num == 1)
        {
            if (GameMaster.choice_1 == 0)
            {
                same = GameMaster.Choice_1_dark;
                placetext = "% thinks they have no home";
            }
            else
            {
                same = GameMaster.Choice_1_light;
                placetext = "% thinks they have a home";
            }
            total = GameMaster.Choice_1_dark + GameMaster.Choice_1_light;
        }
        else if (num == 2)
        {
            if (GameMaster.choice_2 == 0)
            {
                same = GameMaster.Choice_2_dark;
                placetext = "% do not believe in love";
            }
            else
            {
                same = GameMaster.Choice_2_light;
                placetext = "% believes in love";
            }
            total = GameMaster.Choice_2_dark + GameMaster.Choice_2_light;
        }

        else if (num == 3)
        {
            if (GameMaster.choice_3 == 0)
            {
                same = GameMaster.Choice_3_dark;
                placetext = "% does not like stepping out of their comfort zone";
            }
            else
            {
                same = GameMaster.Choice_3_light;
                placetext = "% are adventurous in life";
            }
            total = GameMaster.Choice_3_dark + GameMaster.Choice_3_light;
        }
        else if (num == 4)
        {
            if (GameMaster.choice_4 == 0)
            {
                same = GameMaster.Choice_4_dark;
                placetext = "% wants to start a new beginning";
            }
            else
            {
                same = GameMaster.Choice_4_light;
                placetext = "% are content with what they have";
            }
            total = GameMaster.Choice_4_dark + GameMaster.Choice_4_light;
        }
        else if (num == 5)
        {
            if (GameMaster.choice_5 == 0)
            {
                same = GameMaster.Choice_5_dark;
                placetext = "% values money more";
            }
            else
            {
                same = GameMaster.Choice_5_light;
                placetext = "% values passion over money";
            }
            total = GameMaster.Choice_5_dark + GameMaster.Choice_5_light;
        }
        prct = same / total;
        PrctText.text = (prct*100).ToString("F0") + placetext;

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
