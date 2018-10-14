using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityEngine.UI;


public class QuickDirtyScript : MonoBehaviour
{

    public InputField m_storageImage;
    public InputField m_imagePath;
    public RawImage m_rawImage;
    public AspectRatioFitter m_ratioFitter;

    public string m_giventImagePath;

    void Start()
    {
        m_imagePath.onValueChanged.AddListener(LoadImage);
        string imagePath = PlayerPrefs.GetString("StorageImagePath");
        m_storageImage.text = imagePath;
    }

    private void LoadImage(string path)
    {

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            LoadFileImage(path);
        //    StartCoroutine(LoadFileImage(path));
        }
    }

    private void LoadFileImage(string path)
    {
        //D:\#Wiki\2018_10_14_Wiki_GitMarkdownClone\Wiki\Images\JamsCenter.jpg
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);

        tex.LoadImage(File.ReadAllBytes(path));
        m_ratioFitter.aspectRatio = (float)tex.width / (float)tex.height;
        m_rawImage.texture = tex;
      //  m_imagePath.text = "";


    }
    private IEnumerator LoadImageFromWeb(string path)
    {
        //D:\#Wiki\2018_10_14_Wiki_GitMarkdownClone\Wiki\Images\JamsCenter.jpg
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(path))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);
            if (www.error == "")
            {
                m_rawImage.texture = tex;
                m_ratioFitter.aspectRatio = tex.width / tex.height;
            }
            m_imagePath.text = "";
        }

    }

    public void OnDestroy()
    {
        PlayerPrefs.SetString("StorageImagePath", m_storageImage.text);
    }
    

    public void OpenExplorer()
    {
        Application.OpenURL(Application.dataPath);

    }
}
