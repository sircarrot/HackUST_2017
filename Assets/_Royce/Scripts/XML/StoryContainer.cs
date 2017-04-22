using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("StoryCollection")]
public class StoryContainer {

    [XmlArray("Story")]
    [XmlArrayItem("line")]
    public List<StoryClass> storylines = new List<StoryClass>();

    public static StoryContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(StoryContainer));
        var _xml = Resources.Load<TextAsset>(path);
        var reader = new StringReader(_xml.text);
        var storylines = serializer.Deserialize(reader) as StoryContainer;

        reader.Close();

        return storylines;
    }
}