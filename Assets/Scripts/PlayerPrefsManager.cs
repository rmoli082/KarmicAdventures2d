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

    public static void SetHealth(int health) {
        PlayerPrefs.SetInt("health", health);
    }

    public static void SavePlayerState(int health) {
        PlayerPrefs.SetInt("health", health);
    }

    public static void ResetPlayerState(int startHealth) {
        PlayerPrefs.SetInt("health", startHealth);
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
