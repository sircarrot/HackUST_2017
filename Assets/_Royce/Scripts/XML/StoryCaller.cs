using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCaller : MonoBehaviour {

    public GameObject storyclass;
    public int linenumber;
    public int linetype; // 1 dark, 2 light, other grey


	// Use this for initialization
	void Start () {
	
    if(linetype == 1)
        {
           gameObject.GetComponent<TextMesh>().text = storyclass.GetComponent<StoryScript>().DarkLine(linenumber);
           gameObject.GetComponent<TextMesh>().text = gameObject.GetComponent<TextMesh>().text.Replace("\\n", "\n");
        }
        else if(linetype == 2)
        {
            gameObject.GetComponent<TextMesh>().text = storyclass.GetComponent<StoryScript>().LightLine(linenumber);
            gameObject.GetComponent<TextMesh>().text = gameObject.GetComponent<TextMesh>().text.Replace("\\n", "\n");
        }
        else
        {
            gameObject.GetComponent<TextMesh>().text = storyclass.GetComponent<StoryScript>().GreyLine(linenumber);
            gameObject.GetComponent<TextMesh>().text = gameObject.GetComponent<TextMesh>().text.Replace("\\n", "\n");
        }

    }
}
