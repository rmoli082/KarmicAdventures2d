using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager
{
    public static int GetLives() {
        if (PlayerPrefs.HasKey("lives")) {
            return PlayerPrefs.GetInt("lives");
        } else {
            return 0;
        }
    }

    public static void SetLives(int lives) {
        PlayerPrefs.SetInt("lives", lives);
    }

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

    public static void SavePlayerState(int lives, int health) {
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.SetInt("health", health);
    }

    public static void ResetPlayerState(int startLives, int startHealth) {
        PlayerPrefs.SetInt("lives", startLives);
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
