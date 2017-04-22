using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class StoryClass
{
    [XmlAttribute("name")]
    public int line;

    [XmlElement("dark")]
    public string dark_text;

    [XmlElement("light")]
    public string light_text;

    [XmlElement("grey")]
    public string grey_text;
}