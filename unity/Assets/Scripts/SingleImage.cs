using UnityEngine;
using System.Collections;
using Assets;

public class SingleImage : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        //string image = ExchangeData.imageName;
        changeTexture();
        //Debug.Log(image);
    }

    // Update is called once per frame
    void Update()
    {
        if (Cardboard.SDK.CardboardTriggered)
        {
            Debug.Log("Cardboard Clicked");
            Application.LoadLevel("Scenes/ImageEnlarged");
        }

    }

    void changeTexture()
    {
        
        GetComponent<Renderer>().material.mainTexture = ExchangeData.tex;
    }
}
