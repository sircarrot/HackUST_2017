using UnityEngine;
using System.IO;

public class StoryLoader
{
    public static string path;
    public StoryContainer sc = new StoryContainer();

    public void Load()
    {
        //Loading
        sc = StoryContainer.Load(path);
        Debug.Log("Load");
    }
}