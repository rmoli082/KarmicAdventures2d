using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;

    public Avatar currentAvatar;
    public Stats baseStats;
    
    void Awake()
    {
         if (player == null) {
            player = this.GetComponent<Player>();
        } 
        else if (player != this)
        {
            Destroy(gameObject);
        }
        baseStats = new Stats(new Dictionary<string, int>()
        {
            {"xp", 0},
            {"level", 0},
            {"hpmax", 10},
            {"hpnow", 10},
            {"mpmax", 10},
            {"mpnow", 10},
            {"attack", 10},
            {"defense", 10},
            {"magic", 10},
            {"karma", 10}
        });
        Debug.Log(baseStats.GetStats("attack").ToString());
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("xp"))
        {
            baseStats.stats["xp"] = PlayerPrefsManager.GetXP();
        }
    }
}
