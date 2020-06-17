using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager
{
    public static int GetHealth() {
        if (PlayerPrefs.HasKey("health")) {
            return PlayerPrefs.GetInt("health");
        } else {
            return 0;
        }
    }

    public static int GetXP() {
        if (PlayerPrefs.HasKey("xp"))
        {
            return PlayerPrefs.GetInt("xp");
        }
        else
        {
            return 0;
        }
    }

    public static void SetXP(int XP)
    {
        PlayerPrefs.SetInt("xp", XP);
    }

    public static void SetHealth(int health) {
        PlayerPrefs.SetInt("health", health);
    }

    public static void SavePlayerState(int health, int xp) {
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.SetInt("xp", xp);
    }

    public static void ResetPlayerState(int startHealth) {
        PlayerPrefs.SetInt("health", startHealth);
        PlayerPrefs.SetInt("xp", 0);
        PlayerPrefs.SetFloat("overworldX", 0);
        PlayerPrefs.SetFloat("overworldY", 0);
        PlayerPrefs.SetFloat("overworldZ", 0);
    }

    public static void PlayerOverworldPosition(float x, float y, float z) {
        PlayerPrefs.SetFloat("overworldX", x);
        PlayerPrefs.SetFloat("overworldY", y);
        PlayerPrefs.SetFloat("overworldZ", z);
    }


}
