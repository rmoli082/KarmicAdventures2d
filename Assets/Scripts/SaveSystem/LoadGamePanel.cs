using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class LoadGamePanel : MonoBehaviour
{
    public GameObject saveButtonPrefab;
    public GameObject contentFrame;
    public static string path; 

    private void Start()
    {
        path = $"{Application.persistentDataPath}/saves/";
        string[] directories = Directory.GetDirectories(path);

        foreach (string dir in directories)
        {
            Debug.Log($"making button: {dir}");
            CreateButton(dir, contentFrame);
        }
    }

    GameObject CreateButton(string dir, GameObject contentFrame)
    {
        GameObject b = Instantiate(saveButtonPrefab);
        string[] separators = { path };
        string[] playerName = dir.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        b.GetComponentInChildren<TextMeshProUGUI>().text = playerName[0];
        b.transform.SetParent(contentFrame.transform, false);
        return b;
    }
}
