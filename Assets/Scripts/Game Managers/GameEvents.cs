using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static System.Action SaveInitiated;
    public static System.Action LoadInitiated;
    public static System.Action InventoryUpdated;
    public static System.Action<string> LocationFound;
    public static System.Action<string> KillSuccessful;
    public static System.Action AwakenEvent;
    public static System.Action XpAwarded;

    public static void OnSaveInitiated()
    {
        SaveInitiated?.Invoke();
    }

    public static void OnLoadInitiated()
    {
        LoadInitiated?.Invoke();
    }

    public static void OnInventoryUpdated()
    {
        InventoryUpdated?.Invoke();
    }

    public static void OnLocationFound(string location)
    {
        LocationFound?.Invoke(location);
    }

    public static void OnKillSuccessful(string tag)
    {
        KillSuccessful?.Invoke(tag);
    }

    public static void OnAwakenEvent()
    {
        AwakenEvent?.Invoke();
    }

    public static void OnXpAwarded()
    {
        XpAwarded?.Invoke();
    }
}
