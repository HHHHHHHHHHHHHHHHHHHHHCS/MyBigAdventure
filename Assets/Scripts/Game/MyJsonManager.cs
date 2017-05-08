using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public abstract class MyJsonManager
{

    protected string filePath;

    protected virtual string Read()
    {
        string result = "";
        if (File.Exists(filePath))
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                result = sr.ReadToEnd();

            }
        }
        return result;
    }


    protected virtual List<T> ToList<T>()
    {
        return JsonConvert.DeserializeObject<List<T>>(Read());
    }

    protected virtual string Save<T>(List<T> list)
    {
        string jsonStr = JsonConvert.SerializeObject(list);
        using (StreamWriter sw = File.CreateText(filePath))
        {
            sw.Write(jsonStr);
        }
        return jsonStr;
    }

}
