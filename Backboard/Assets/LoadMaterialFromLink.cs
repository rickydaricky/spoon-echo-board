using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Dummiesman;

public class LoadMaterialFromLink : MonoBehaviour
{
    
    public string url = string.Empty;
    private GameObject model;
    Texture2D img;
    private string objPath = "Insert Link Here:";
    string error = string.Empty;
 
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(LoadImg());

        if (!gameObject.GetComponent<MeshRenderer>())
            gameObject.AddComponent<MeshRenderer>();

    }

    IEnumerator LoadImg() {
        while (true)
        {
            yield return 0;
            WWW imgLink = new WWW(url);
            yield return imgLink;
            img = imgLink.texture;

            model = this.gameObject;
            if (!(url == "Insert Link Here:")) {
                model.GetComponent<Renderer>().material.mainTexture = img;
            }
            else {
                model.GetComponent<Renderer>().material = Resources.Load("MauveSmooth", typeof(Material)) as Material;
            }
        }
    }
    
    void OnGUI() {
        objPath = GUI.TextField(new Rect(0, 0, 512, 64), objPath);
        GUI.Label(new Rect(0, 0, 512, 64), "");
        if (GUI.Button(new Rect(0, 64, 512, 64), "Load Image")) {
            url = objPath;
        }
        

    }
    
}