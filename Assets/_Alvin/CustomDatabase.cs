using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomDatabase : MonoBehaviour {

    public Text TextLog;

    public string serverMainName = "localhost";
    public string serverUsername = "root";
    public string serverPassword = "";
    public string serverDatabase = "hackust_2017";


    public string url_insertValue = "http://10.89.28.103/HackUST_2017/add_entry.php";
    public string url_getValue = "http://10.89.28.103/HackUST_2017/get_entry.php";

    private WWWForm StablishedServer()
    {
        WWWForm webForm = new WWWForm();
        webForm.AddField("serverMainName", serverMainName);
        webForm.AddField("serverUsername", serverUsername);
        webForm.AddField("serverPassword", serverPassword);
        webForm.AddField("serverDatabase", serverDatabase);
        return webForm;
    }

    public int choice_1;
    public int choice_2;
    public int choice_3;
    public int choice_4;
    public int choice_5;
    public bool gf;

    public void Insert_data()
    {
        StartCoroutine(InsertData());
    }

    private IEnumerator InsertData()
    {
        WWWForm setForm = StablishedServer();
        setForm.AddField("choice_1", choice_1);
        setForm.AddField("choice_2", choice_2);
        if(gf == true)
        {
            setForm.AddField("choice_3", choice_3);
            setForm.AddField("choice_4", 2);
        }
        else
        {
            setForm.AddField("choice_3", 2);
            setForm.AddField("choice_4", choice_4);
        }
        
        setForm.AddField("choice_5", choice_5);

        WWW database = new WWW(url_insertValue,setForm);
        yield return database;
        Debug.Log(database.text);
        TextLog.text = database.text;
    }

    public int Choice_1_light;
    public int Choice_1_dark;

    public int Choice_2_light;
    public int Choice_2_dark;

    public int Choice_3_light;
    public int Choice_3_dark;

    public int Choice_4_light;
    public int Choice_4_dark;

    public int Choice_5_light;
    public int Choice_5_dark;

    public EndgameBar gameBar1;
    public EndgameBar gameBar2;
    public EndgameBar gameBar3;
    public EndgameBar gameBar4;
    public EndgameBar gameBar5;

    public void Get_data()
    {
        StartCoroutine(GetData());
    }

    private IEnumerator GetData()
    {
        WWWForm setForm = StablishedServer();

        WWW database = new WWW(url_getValue, setForm);
        yield return database;
        Debug.Log(database.text);
        getDataClass getArray = JsonUtility.FromJson<getDataClass>(database.text);

        Choice_1_light = getArray.Choice_1_light;
        Choice_1_dark = getArray.Choice_1_dark;

        Choice_2_light = getArray.Choice_2_light;
        Choice_2_dark = getArray.Choice_2_dark;

        Choice_3_light = getArray.Choice_3_light;
        Choice_3_dark = getArray.Choice_3_dark;

        Choice_4_light = getArray.Choice_4_light;
        Choice_4_dark = getArray.Choice_4_dark;

        Choice_5_light = getArray.Choice_5_light;
        Choice_5_dark = getArray.Choice_5_dark;

        gameBar1.callingFunk();
        gameBar2.callingFunk();
        gameBar3.callingFunk();
        gameBar4.callingFunk();
        gameBar5.callingFunk();

    }
    
    public class getDataClass
    {
        public int Choice_1_light;
        public int Choice_1_dark;

        public int Choice_2_light;
        public int Choice_2_dark;

        public int Choice_3_light;
        public int Choice_3_dark;

        public int Choice_4_light;
        public int Choice_4_dark;

        public int Choice_5_light;
        public int Choice_5_dark;
    }

    // Use this for initialization
    void Awake ()
    {
        choice_1 = PlayerPrefs.GetInt("Choice1");
        choice_2 = PlayerPrefs.GetInt("Choice2");
        choice_3 = PlayerPrefs.GetInt("Choice3");
        choice_4 = PlayerPrefs.GetInt("Choice4");
        choice_5 = PlayerPrefs.GetInt("Choice5");
        if(PlayerPrefs.GetInt("gf") == 1)
        {
            gf = true;
        }
        else
        {
            gf = false;
        }
        StartCoroutine(GetData());
        StartCoroutine(InsertData());

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
