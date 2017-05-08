using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class LevelJsonManager : MyJsonManager
{
    private static LevelJsonManager _instance;


    public static LevelJsonManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new LevelJsonManager();
#if UNITY_ANDROID
                _instance.filePath = string.Format("{0}/{1}", Application.persistentDataPath, fileName);
#elif UNITY_IPHONE
_instance.filePath = string.Format("{0}/{1}", Application.persistentDataPath, fileName);
#else
                _instance.filePath = string.Format("{0}/{1}", Application.dataPath, fileName);
#endif
            }
            return _instance;
        }

    }

    protected const string fileName = "LevelInfo.json";



    public new string Read()
    {
        return base.Read();
    }


    public List<LevelInfo> ToList()
    {
        return base.ToList<LevelInfo>();
    }

    public string Save(List<LevelInfo> list)
    {
        return base.Save(list);
    }

    public string UpdateData(int level, int star)
    {
        var list = ToList();
        if (star > list[level].star)
        {
            list[level].star = star;
        }

        return Save(list);
    }
}
