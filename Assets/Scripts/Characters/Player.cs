﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public static Player player;

    public GameObject weapon;

    public float timeInvincible = 2.0f;
    public float invincibleTimer;
    public bool isInvincible;

    public float mpRegenTime;
    public float hpRegenTime;
    
    float hpReturn;
    float mpReturn;

    Transform respawnPosition;

    float regenFormula;

    void Awake()
    {
         if (player == null) {
            player = this.GetComponent<Player>();
        } 
        else if (player != this)
        {
            Destroy(gameObject);
        }

        invincibleTimer = -1.0f;
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (CharacterSheet.charSheet.baseStats.GetStats("currentHP") < CharacterSheet.charSheet.baseStats.GetStats("hp") 
            && Time.time >= hpReturn) 
        {
            CharacterSheet.charSheet.ChangeHealth(1);
            if (CharacterSheet.charSheet.selectedSkills.ContainsKey("Stamina"))
            {
                regenFormula = 1 - (CharacterSheet.charSheet.selectedSkills["Stamina"] * 0.03f);
                hpReturn = Time.time + (hpRegenTime * regenFormula);
            }
            else
            {
                hpReturn = Time.time + hpRegenTime;
            }
            
        }

        if (CharacterSheet.charSheet.baseStats.GetStats("currentMP") < CharacterSheet.charSheet.baseStats.GetStats("mp")
           && Time.time >= mpReturn)
        {
            CharacterSheet.charSheet.ChangeMP(1);
            if (CharacterSheet.charSheet.selectedSkills.ContainsKey("Stamina"))
            {
                regenFormula = 1 - (CharacterSheet.charSheet.selectedSkills["Stamina"] * 0.03f);
                mpReturn = Time.time + (mpRegenTime * regenFormula);
            }
            else
            {
                mpReturn = Time.time + mpRegenTime;
            }
        }
        CharacterSheet.charSheet.ChangeHealth(0);
    }
    public void SetAvatar(int avatar)
    {
        switch (avatar)
        {
            case -1:
                player.GetComponent<SpriteRenderer>().color = Color.white;
                player.GetComponent<PlayerController>().projectilePrefab = (GameObject)Resources.Load("Projectiles/Projectile");
                break;
            case 0:
                player.GetComponent<SpriteRenderer>().color = Color.red;
                player.GetComponent<PlayerController>().projectilePrefab = (GameObject)Resources.Load("Projectiles/SunProjectile");
                player.GetComponent<PlayerController>().projectilePrefab.GetComponent<Projectile>().numberOfTargets = Random.Range(2, 5) + ((CharacterSheet.charSheet.buffedStats.GetStats("special") - 10) / 2); ;
                break;
            case 1:
                player.GetComponent<SpriteRenderer>().color = new Color(128f, 128f, 128f, 0.5f);
                break;
            default:
                break;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (CharacterSheet.charSheet.currentAvatar != null)
            SetAvatar(CharacterSheet.charSheet.currentAvatar.avatarID);
    }
    

}
