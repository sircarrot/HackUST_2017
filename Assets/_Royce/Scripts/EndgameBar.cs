using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameBar : MonoBehaviour {

    public CustomDatabase GameMaster;
    public GameObject Parent;
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
        if(num == 3 && GameMaster.gf == false)
        {
            Parent.gameObject.SetActive(false);
        }
        if (num == 4 && GameMaster.gf == true)
        {
            Parent.gameObject.SetActive(false);
        }

        if (num == 1)
        {
            if (GameMaster.choice_1 == 0)
            {
                same = GameMaster.Choice_1_dark;
            }
            else
            {
                same = GameMaster.Choice_1_light;
            }
            total = GameMaster.Choice_1_dark + GameMaster.Choice_1_light;
        }
        else if (num == 2)
        {
            if (GameMaster.choice_2 == 0)
            {
                same = GameMaster.Choice_2_dark;
            }
            else
            {
                same = GameMaster.Choice_2_light;
            }
            total = GameMaster.Choice_2_dark + GameMaster.Choice_2_light;
        }

        else if (num == 3)
        {
            if (GameMaster.choice_3 == 0)
            {
                same = GameMaster.Choice_3_dark;
            }
            else
            {
                same = GameMaster.Choice_3_light;
            }
            total = GameMaster.Choice_3_dark + GameMaster.Choice_3_light;
        }
        else if (num == 4)
        {
            if (GameMaster.choice_4 == 0)
            {
                same = GameMaster.Choice_4_dark;
            }
            else
            {
                same = GameMaster.Choice_4_light;
            }
            total = GameMaster.Choice_4_dark + GameMaster.Choice_4_light;
        }
        else if (num == 5)
        {
            if (GameMaster.choice_5 == 0)
            {
                same = GameMaster.Choice_5_dark;
            }
            else
            {
                same = GameMaster.Choice_5_light;
            }
            total = GameMaster.Choice_5_dark + GameMaster.Choice_5_light;
        }
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
