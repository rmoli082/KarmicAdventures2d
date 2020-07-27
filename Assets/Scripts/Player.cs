using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;

    public Avatar currentAvatar = null;
    public Stats baseStats;

    public float mpRegenTime;
    public float hpRegenTime;

    RubyController playerController;
    float hpReturn;
    float mpReturn;
    
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
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("xp"))
        {
            baseStats.stats["xp"] = PlayerPrefsManager.GetXP();
        }
        playerController = this.gameObject.GetComponent<RubyController>();
    }

    void Update()
    {
        if (playerController.currentHealth < baseStats.GetStats("hpmax") 
            && Time.time >= hpReturn) 
        {
            playerController.ChangeHealth(1);
            hpReturn = Time.time + hpRegenTime;
        }
        ReloadStats();
    }

    public void ReloadStats()
    {
        baseStats.stats["level"] = (Mathf.FloorToInt(50 + Mathf.Sqrt(625 + 100 * 
            Player.player.baseStats.GetStats("xp")))/100);
        baseStats.stats["hpmax"] = baseStats.GetStats("defense") + (2 * baseStats.GetStats("level"));
        baseStats.stats["mpmax"] = baseStats.GetStats("magic") + (2 * baseStats.GetStats("level")) + 1;
    }

}
