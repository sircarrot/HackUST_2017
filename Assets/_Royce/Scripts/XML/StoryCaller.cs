using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryCaller : MonoBehaviour {

    public GameObject storyclass;
    public int linenumber;
    public int linetype; // 1 dark, 2 light, o grey


	// Use this for initialization
	void Start () {
	
    if(linetype == 1)
        {
            Debug.Log(storyclass.GetComponent<StoryScript>().DarkLine(linenumber));
        }
    else if(linetype == 2)
        {
            Debug.Log(storyclass.GetComponent<StoryScript>().LightLine(linenumber));
        }
    else
        {
            Debug.Log(storyclass.GetComponent<StoryScript>().GreyLine(linenumber));
        }

	}
}
