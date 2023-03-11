using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class guardar : MonoBehaviour
{
    private string path;
    private string fileInfo;
    private XmlDocument xmlDoc;
    private TextAsset textXml;
    private List<data> datos;
    private string fileName;

    struct data{
        public string nombre;
        public int score;
    }
    
    void Awake()
    {
        fileName = "data";
        datos = new List<data>();
    }

    void Start(){
        LoadXMLFromAssets();
        mostrar();
    }
    void Update()
    {
        
    }

    private void LoadXMLFromAssets(){
        xmlDoc = new XmlDocument();
        if(System.IO.File.Exists(getPath())){
            xmlDoc.LoadXml(System.IO.File.ReadAllText(getPath()));
        }else{
            textXml = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
            xmlDoc.LoadXml(textXml.text);
        }
    }

    private void mostrar(){
        XmlNode rootNode = xmlDoc.SelectSingleNode("data");
        XmlNode score = rootNode.SelectSingleNode("score");
        if(score.InnerText == ""){
            Debug.Log("no tiene score registrado");
        }else{
            Debug.Log(score.InnerText);
        }
    }

    private string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath + "/Resources"+fileName;
        #elif UNITY_ANDROID
        return Application.persistentDataPath+fileName;
        #else
        return Application.dataPath + "/"+fileName;
        #endif
    }
}
