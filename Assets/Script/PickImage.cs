using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

//Source: https://www.youtube.com/watch?v=YCWtFG3Jv80

public class PickImage : MonoBehaviour
{

    public string FinalPath;



    public void LoadFile()
    {
        string Filetype = NativeFilePicker.ConvertExtensionToFileType("All files");

        NativeFilePicker.Permission permission = NativeFilePicker.PickFile((path) =>
            {
                if (path == null)
                    Debug.Log("Operation cancelled");
                else
                {
                    FinalPath = path;
                    Debug.Log("Picked files:" + FinalPath);
                    StartCoroutine("LoadTexture");
                }
            }, new string[] { Filetype });
    }

    public void SaveFile()
    {
        string filepath = Path.Combine(Application.temporaryCachePath, "test.txt");
        File.WriteAllText(filepath, "Hello World!");

        NativeFilePicker.Permission permission = NativeFilePicker.ExportFile(filepath, (success) => Debug.Log("File exported:" + success));
    }


    public Image Plane;

    IEnumerator LoadTexture()
    {
        WWW www = new WWW(FinalPath);
        while (!www.isDone)
            yield return null;
        Plane.GetComponent<Renderer>().material.mainTexture = www.texture;
    }
}
