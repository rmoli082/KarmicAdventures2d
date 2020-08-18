using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AwakeningManager : MonoBehaviour
{
    public static AwakeningManager awakeningManager;

    public Dictionary<int, Awaken.AwakeningStatus> awakenedList = new Dictionary<int, Awaken.AwakeningStatus>();

    void Awake()
    {
        if (awakeningManager == null)
        {
            awakeningManager = this.GetComponent<AwakeningManager>();
            awakenedList.Clear();
        }
        else if (awakeningManager != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
    }
    public void UpdateList(int awakenedId)
    {
        awakenedList[awakenedId] = Awaken.AwakeningStatus.AWAKE;
    }


    void Save()
    {
        SaveLoad.Save<Dictionary<int, Awaken.AwakeningStatus>>(awakenedList, "Awakened");
    }

    void Load()
    {
        awakenedList.Clear();
        awakenedList = SaveLoad.Load<Dictionary<int, Awaken.AwakeningStatus>>("Awakened");
    }

}
