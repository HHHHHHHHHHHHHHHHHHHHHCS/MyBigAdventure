using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public abstract class MyJsonManager
{

    protected string filePath;

    public virtual string Read()
    {
        string result = "";
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                result = sr.ReadToEnd();

            }
        }
        return result;
    }


    public virtual List<T> ToList<T>()
    {
        return JsonConvert.DeserializeObject<List<T>>(Read());
    }

    public virtual string Save<T>(List<T> list)
    {
        string jsonStr = JsonConvert.SerializeObject(list);
        using (StreamWriter sw = File.CreateText(filePath))
        {
            sw.Write(jsonStr);
        }
        return jsonStr;
    }

}
