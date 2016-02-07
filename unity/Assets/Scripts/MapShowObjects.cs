using UnityEngine;
using System.Collections;
using Assets;
using System.IO;

public class MapShowObjects : MonoBehaviour {
    public float x, y, z;
    private GameObject leftEyeCamera;
    private GameObject rightEyeCamera;
    private RaycastHit objectHitLeft;
    private RaycastHit objectHitRight;
    private GameObject planeHavingMap;
    private GameObject sphere1;
    private GameObject sphere2;
    private GameObject sphere3;
    private GameObject information;
    private string[][] mapInfo;
    private string[][] mapInfoNewYork = new string[][] { new string[] { "Part", "Part ", "Part ", "Part ", "Part " }, new string[] { "Part", "Part", "Part", "Part", "Part" }, new string[] { "Newark", "New York", "Part", "Part", "Part" }, new string[] { "Part", "Part", "Part", "Part", "Part" }, new string[] { "Clifton", "Part", "Part", "New Rochelle", "Part" } };
    private string[][] mapInfoLosAngeles = new string[][] { new string[] { "Part", "Part", "Part", "Part", "Downey" }, new string[] { "Part", "Part", "Huntington Park", "Part", "Part" }, new string[] { "Inglewood", "Part", "Part", "Part", "Part" }, new string[] { "Part", "Part", "Los Angeles", "Part", "Part" }, new string[] { "Part", "Part", "Part", "Part", "Part" } };
    private string[][] mapInfoLasVegas = new string[][] { new string[] { "Part", "Part", "Part", "Part", "Part" }, new string[] { "Part", "Spring Valley", "Part", "Paradise", "Part" }, new string[] { "Part", "Part", "Part", "Part", "Part" }, new string[] { "Part", "Part", "Part", "Las Vegas", "Part" }, new string[] { "Part", "Part", "Part", "North Las Vegas", "Part" } };
    // Use this for initialization
    void Start () {
        string cityLoaded = ExchangeData.search;
        if (cityLoaded == "New York")
        {
            mapInfo = mapInfoNewYork;
        }
        if (cityLoaded == "Los Angeles")
        {
            mapInfo = mapInfoLosAngeles;
        }
        if (cityLoaded == "Las Vegas")
        {
            mapInfo = mapInfoLasVegas;
        }
        //string directory = "Assets/Images/Maps/";
        string directory = "/storage/emulated/0/Maps/";
        string file = directory + cityLoaded.ToLower().Replace(" ", "")+".jpg";
        Texture2D tex = new Texture2D(2, 2);
        byte[] fileData = File.ReadAllBytes(file);
        tex.LoadImage(fileData);
        transform.GetComponent<Renderer>().material.mainTexture = tex;
        leftEyeCamera = GameObject.FindGameObjectWithTag("LeftEyeMainCamera");
        rightEyeCamera = GameObject.FindGameObjectWithTag("RightEyeMainCamera");
        sphere1 = GameObject.FindGameObjectWithTag("CoordSphere1");
        sphere2 = GameObject.FindGameObjectWithTag("CoordSphere2");
        sphere3 = GameObject.FindGameObjectWithTag("CoordSphere3");
        information = GameObject.FindGameObjectWithTag("MapInformation");
    }

    // Update is called once per frame
    void Update () {
        bool leftHit = Physics.Raycast(leftEyeCamera.transform.position, leftEyeCamera.transform.forward, out objectHitLeft);
        bool rightHit = Physics.Raycast(rightEyeCamera.transform.position, rightEyeCamera.transform.forward, out objectHitRight);
        if(leftHit && rightHit && objectHitLeft.transform.tag == "map" && objectHitRight.transform.tag == "map")
        {
            Vector3 pointHit = objectHitLeft.point;
            float topPercentage = 0;
            float rightPercentage = 0;
            rightPercentage = Vector3.Dot((sphere2.transform.position - sphere1.transform.position), (pointHit - sphere1.transform.position)) / (sphere2.transform.position - sphere1.transform.position).sqrMagnitude;
            topPercentage = Vector3.Dot((sphere3.transform.position - sphere1.transform.position), (pointHit - sphere1.transform.position)) / (sphere3.transform.position - sphere1.transform.position).sqrMagnitude;
            int iCoord = (int)(topPercentage / .2);
            int jCoord = (int)(rightPercentage / .2);
            Debug.Log("The points are " + iCoord + " " + jCoord);
            Vector3 fixedPositionOnScreen = new Vector3(x, y, z);
            //information.transform.position = Camera.main.ViewportToWorldPoint(fixedPositionOnScreen);
            TextMesh textShown = information.GetComponent<TextMesh>();
            if (mapInfo[iCoord][jCoord] != "Part")
            {
                textShown.text = mapInfo[iCoord][jCoord];
            }
            else
            {
                textShown.text = "";
            }
        }
    }
}
