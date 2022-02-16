using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDataModel
{
    public string textContent;
    public string picName;
    public int time;

    public TextDataModel(string textContent,string picName,int time)
    {
        this.textContent = textContent;
        this.picName = picName;
        this.time = time;
    }
}
