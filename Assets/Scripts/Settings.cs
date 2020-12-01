using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Settings : MonoBehaviour
{

    public float playerOffset;


    private void Start()
    {
        Save();
    }

    public void Load()
    {

        //load settings from file
        JsonUtility.FromJsonOverwrite(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DanceGame"), this);
    }

    public void Save()
    {
        //create folder for settings if it doesn't exist
        System.IO.Directory.CreateDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DanceGame"));

        //write settings to file
        System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "DanceGame", "settings.json"), JsonUtility.ToJson(this));
    }
}
