using UnityEngine;
using System.Collections;
using System.IO;
using Assets;

public class ImageView : MonoBehaviour {

    // Use this for initialization
    private string searchTerm;
    void Start () {
        //ExchangeData.search = "Las Vegas";
        searchTerm = ExchangeData.search;
        string name = searchTerm.ToLower();
        name = name.Replace(' ', '_');
        Debug.Log(name);
        string dataPath = Application.dataPath;
        Debug.Log(dataPath);
        string directory = "/storage/emulated/0/teamX/" + name;
        //string directory = "C:/Users/Abhishek/Desktop/teamX/" + name;
        Debug.Log(directory);
        int i = 1;
        foreach (string file in Directory.GetFiles(directory, "*.jpg"))
        {
            Debug.Log(file);
            Texture2D tex = new Texture2D(2, 2);
            byte[] fileData = File.ReadAllBytes(file);
            tex.LoadImage(fileData);
            foreach (Transform child in transform)
            {
                if (child.gameObject.name == "image" + i)
                {
                    child.gameObject.GetComponent<Renderer>().material.mainTexture = tex;
                }
            }
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
