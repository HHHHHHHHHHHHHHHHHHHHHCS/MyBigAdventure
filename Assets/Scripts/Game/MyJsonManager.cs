using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class MyJsonManager
{
    private static MyJsonManager _instance;

    public static MyJsonManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log(Application.dataPath);
                _instance = new MyJsonManager();
            }
            return _instance;
        }
    }

    private const string fileName = "MyData.txt";

    #if UNITY_EDITOR
        string filepath = Application.dataPath ;
#elif UNITY_IPHONE
        string filepath = Application.persistentDataPath;
#elif UNITY_ANDROID
        string filepath = Application.persistentDataPath ;
#endif

    public bool CheckExists()
    {
        return CheckExists(filepath, fileName);
    }

    public bool CheckExists(string path,string name)
    {
        FileInfo t = new FileInfo(path + "//" + name);
        if (!t.Exists)
        {
            //如果此文件不存在则创建
            return false;
        }
        else
        {
            //如果此文件存在则打开
            return true;
        }
    }


    public void CreateFile(string info)
    {
         CreateFile(filepath, fileName,info);
    }
    /**
      * path：文件创建目录
      * name：文件的名称
      *  info：写入的内容
      */
    public void CreateFile(string path, string name, string info)
    {
        //文件流信息
        StreamWriter sw;
        FileInfo t = new FileInfo(path + "//" + name);
        if (!t.Exists)
        {
            //如果此文件不存在则创建
            sw = t.CreateText();
        }
        else
        {
            //如果此文件存在则打开
            sw = t.AppendText();
        }
        //以行的形式写入信息
        sw.WriteLine(info);
        //关闭流
        sw.Close();
        //销毁流
        sw.Dispose();
    }

    public string LoadFile()
    {
        return LoadFile(filepath, fileName);
    }

    /**
     * path：读取文件的路径
     * name：读取文件的名称
     */
    String LoadFile(string path, string name)
    {
        if(!CheckExists(path,name))
        {
            CreateFile(path, name,"");
        }
        //使用流的形式读取
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + name);
        }
        catch (Exception e)
        {
            //路径与名称未找到文件则直接返回空
            return null;
        }

        string allInfo = "";
        string line;
        ArrayList arrlist = new ArrayList();
        while ((line = sr.ReadLine()) != null)
        {
            //一行一行的读取
            //将每一行的内容存入数组链表容器中
            allInfo += line;
        }
        //关闭流
        sr.Close();
        //销毁流
        sr.Dispose();
        //将数组链表容器返回
        return allInfo;
    }

    public void UpdateFile(string info)
    {
        UpdateFile(filepath, fileName,info);
    }

    public void UpdateFile(string path,string name,string info)
    {
        if (!CheckExists(path, name))
        {
            CreateFile(path, name, "");
        }
        

        try
        {
            //使用流的形式读写
            FileStream fs = new FileStream(path + "//" + name, FileMode.Create);
            fs.SetLength(0);
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(info);
            fs.Write(byteArray, 0, byteArray.Length);
        }
        catch (Exception e)
        {
            //路径与名称未找到文件则直接返回空
            return ;
        }
    }


    public void DeleteFile()
    {
        DeleteFile(filepath, fileName);
    }
    /**
     * path：删除文件的路径
     * name：删除文件的名称
     */
    public void DeleteFile(string path, string name)
    {
        File.Delete(path + "//" + name);

    }

}
