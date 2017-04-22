using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryScript : MonoBehaviour {

    public string FileName;

    private static StoryLoader myTarget = new StoryLoader();

    void Awake()
    {
        StoryLoader.path = FileName;
        myTarget.Load();
    }
    
    public string DarkLine(int linenumber)
    {
        return myTarget.sc.storylines[linenumber].dark_text;
    }
    public string LightLine(int linenumber)
    {
        return myTarget.sc.storylines[linenumber].light_text;
    }
    public string GreyLine(int linenumber)
    {
        return myTarget.sc.storylines[linenumber].grey_text;
    }
}
