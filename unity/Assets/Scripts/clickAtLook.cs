using UnityEngine;
using Assets;
using System.Collections;
using System;
using System.IO;

public class clickAtLook : MonoBehaviour {
    public string tagName;
    public string functionToPerform;
    private GameObject mainCamera;
    private GameObject leftEyeCamera;
    private GameObject rightEyeCamera;
    private RaycastHit objectHitLeft;
    private RaycastHit objectHitRight;
    private GameObject planeHavingPhotos;
    private System.DateTime lastHitTime;
    private bool clickTimeCounting = false;
    private AndroidJavaObject intent = null;
    private AndroidJavaObject activityContext = null;
    // Use this for initialization
    void Start () {
        ExchangeData.search = "Los Angeles";
        if (!transform.tag.Contains("Thumbnail"))
        {
            InitializeScreen(ExchangeData.search.Replace(" ", ""));
        }
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        planeHavingPhotos = GameObject.FindGameObjectWithTag(tagName);
        leftEyeCamera = GameObject.FindGameObjectWithTag("LeftEyeMainCamera");
        rightEyeCamera = GameObject.FindGameObjectWithTag("RightEyeMainCamera");
        initializePlugin();
        Debug.Log("Yes");
        
    }

    void initializePlugin()
    {
        using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        }
        using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.intent.example.IntentStart"))
        {
            if (pluginClass != null)
            {
                intent = pluginClass.CallStatic<AndroidJavaObject>("instance");
                intent.Call("setContext", activityContext);
            }
        }
    }
    void InitializeScreen(String searchQuery) {
        Texture2D tex = new Texture2D(2,2);
        string directory = "/storage/emulated/0/InitialScreen/";
        //string directory = "Assets/Images/PlaneFixedImages/";
        string fileName = searchQuery+transform.tag+".jpg";
        byte[] fileData = File.ReadAllBytes(directory+fileName);
        tex.LoadImage(fileData);
        transform.gameObject.GetComponent<Renderer>().material.mainTexture = tex;
    }

    // Update is called once per frame
    void Update () {
        LookForward();
	}

    private void LookForward()
    {
        Debug.Log("yes");
        bool leftEyeHitCorrect = Physics.Raycast(leftEyeCamera.transform.position, leftEyeCamera.transform.forward, out objectHitLeft);
        bool rightEyeHitCorrect = Physics.Raycast(rightEyeCamera.transform.position, rightEyeCamera.transform.forward, out objectHitRight);
        if (leftEyeHitCorrect && rightEyeHitCorrect && objectHitRight.transform.tag == tagName && objectHitLeft.transform.tag == tagName)
        {
            if (clickTimeCounting)
            {
                var diffInSeconds = (System.DateTime.Now - lastHitTime).TotalSeconds;
                if (diffInSeconds > 1)
                {
                    ShowProgress(planeHavingPhotos, new int[] { 1}, true);
                }
                if (diffInSeconds > 2)
                {
                    ShowProgress(planeHavingPhotos, new int[] { 2 }, true);
                }
                if (diffInSeconds > 3)
                {
                    ShowProgress(planeHavingPhotos, new int[] { 3 }, true);
                }
                if (diffInSeconds > 4)
                {
                    ShowProgress(planeHavingPhotos, new int[] { 4 }, true);
                }
                if (diffInSeconds > 5)
                {
                    ClickFunction();
                }
            }
            else
            {
                lastHitTime = System.DateTime.Now;
                clickTimeCounting = true;
            }
        }
        else
        {
            clickTimeCounting = false;
            ShowProgress(planeHavingPhotos, new int[] { 1, 2, 3, 4 }, false);
        }

    }

    private void ClickFunction()
    {
        //Debug.Log("the function performed is " + functionToPerform);
        switch (functionToPerform)
        {
            case "ImageView" :
                ImageView();
                break;
            case "VideoView":
                VideoView();
                break;
            case "WikiView":
                WikiView();
                break;
            case "MapView":
                MapView();
                break;
            case "SingleImage":
                SingleImage();
                break;

        }
        clickTimeCounting = false;
        
    }

    public void ImageView()
    {
        Debug.Log("Image");
        Application.LoadLevel("Scenes/ImageEnlarged");
    }

    public void VideoView()
    {
        clickTimeCounting = false;
        ShowProgress(planeHavingPhotos, new int[] { 1, 2, 3, 4 }, false);
        //activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        //{
            intent.Call("changeActivity", ExchangeData.search.ToLower().Replace(" ", "_") + ".mp4");
        //}));
        //clickTimeCounting = false;
        //ShowProgress(planeHavingPhotos, new int[] { 1, 2, 3, 4 }, false);
    }

    public void WikiView()
    {
        Application.LoadLevel("Scenes/WikiEnlarged");
    }
    public void MapView()
    {
        Application.LoadLevel("Scenes/MapEnlarged");
    }

    public void SingleImage()
    {
        ExchangeData.tex = (Texture2D)objectHitRight.transform.gameObject.GetComponent<Renderer>().material.mainTexture;
        Application.LoadLevel("Scenes/SingleImage");

    }
    private void ShowProgress(GameObject plane, int[] indexes, bool doShow)
    {
        Transform planeTransform = plane.transform;
        for (int i = 0; i < indexes.Length; i++)
        {
            GameObject childPlane = planeTransform.GetChild(indexes[i]-1).gameObject;
            MeshRenderer childPlaneRenderer = childPlane.GetComponent<MeshRenderer>();
            childPlaneRenderer.enabled = doShow;
        }
    }
}
