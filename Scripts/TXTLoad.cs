using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TXTLoad : MonoBehaviour
{
    public static TXTLoad instance = new TXTLoad();
    int index = 0;
    List<string> txt;
    //private void Awake()
    //{
    //    instance = this;
    //    index = 0;
    //}
    public void loadScripts(string txtFileName)
    {
        index = 0;
        txt = new List<string>();
        StreamReader stream = new StreamReader("Assets/TextContent/" + txtFileName);
        while (!stream.EndOfStream)
        {
            txt.Add(stream.ReadLine());

        }
        stream.Close();
    }

    public TextDataModel loadNext()
    {
        if (index < txt.Count)
        {
            string[] datas = txt[index].Split('|');
            string talk = datas[0];
            string picName = datas[1];
            int time =  int.Parse(datas[2]);
            index++;
            return new TextDataModel(talk, picName,time);
        }
        else
        {
            return null;
        }
    }


}
