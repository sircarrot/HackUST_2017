using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{

    public bool screenshotTaken = true;


    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID
        if (!UniAndroidPermission.IsPermitted(AndroidPermission.WRITE_EXTERNAL_STORAGE))
        {
            UniAndroidPermission.RequestPremission(AndroidPermission.WRITE_EXTERNAL_STORAGE);
        }
#endif

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Share()
    {
        screenshotTaken = false;
        StartCoroutine(ShareRoutine());
    }

    IEnumerator ShareRoutine()
    {
        string imgName = "Screenshot.png";
        string imgPath = Application.persistentDataPath + "/" + imgName;
        if (!screenshotTaken)
        {
            yield return new WaitForEndOfFrame();
            System.IO.File.Delete(imgPath);

            int width = Screen.width;
            int height = Screen.height;
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();
            byte[] bytes = tex.EncodeToPNG();
            Texture2D.Destroy(tex);
            System.IO.File.WriteAllBytes(imgPath, bytes);

            print(Application.persistentDataPath);

            screenshotTaken = true;
        }





        //execute the below lines if being run on a Android device
#if UNITY_ANDROID
        //Reference of AndroidJavaClass class for intent
        AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
        //Reference of AndroidJavaObject class for intent
        AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        ////set the type of sharing that is happening

        ////add data to be passed to the other activity i.e., the data to be sent


        //instantiate the class Uri
        AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");

        ////instantiate the object Uri with the parse of the url's file
        AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + imgPath);

        ////call putExtra with the uri object of the file
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "file://" + imgPath);


        ////set the type of file
        intentObject.Call<AndroidJavaObject>("setType", "*/*");
        //intentObject.Call<AndroidJavaObject>("setType", "image/png");
        //intentObject.Call<AndroidJavaObject>("setType", "text/plain");

        //get the current activity
        AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
        //start the activity by sending the intent data
        currentActivity.Call("startActivity", intentObject);
#endif
    }
}