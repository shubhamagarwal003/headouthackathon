using UnityEngine;
using System.Collections;
using Assets;

public class wikiEnlarge : MonoBehaviour {

    // Use this for initialization
    private string textExample;
    private TextMesh textLR;
    public string tagName;
    void Start () {
        textInitialise();
	}

    void textInitialise()
    {
        textLR = GetComponent<TextMesh>();
        setMeshRenderer(ExchangeData.search.Replace(" ", "") + "Data");
    }

    void setMeshRenderer(string id)
    {
        GameObject NY = GameObject.FindGameObjectWithTag("NewYorkData");
        NY.GetComponent<Renderer>().enabled = false;
        GameObject LA = GameObject.FindGameObjectWithTag("LosAngelesData");
        LA.GetComponent<Renderer>().enabled = false;
        GameObject LV = GameObject.FindGameObjectWithTag("LasVegasData");
        LV.GetComponent<Renderer>().enabled = false;

        GameObject gameObject = GameObject.FindGameObjectWithTag(id);
        gameObject.GetComponent<Renderer>().enabled = true;

    }
	// Update is called once per frame
	void Update () {
	
	}
}
