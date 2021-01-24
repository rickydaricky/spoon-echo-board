using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadImage : MonoBehaviour
{
    public string url = "https://pngimg.com/uploads/arctic_fox/arctic_fox_PNG41380.png";
    Texture2D img;

    void Start() {
        StartCoroutine(LoadImg());
    }

    IEnumerator LoadImg() {
        yield return 0;
        WWW imgLink = new WWW(url);
        yield return imgLink;
        img = imgLink.texture;
    }

    void OnGUI () {
        GUILayout.Label(img);
    }
}