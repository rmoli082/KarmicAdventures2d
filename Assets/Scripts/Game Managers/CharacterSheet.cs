using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterSheet : MonoBehaviour
{
    public static CharacterSheet charSheet;

    public string playerName;
    public Avatar currentAvatar;
    public Stats baseStats;
    public Stats buffedStats;
    public Stats derivedStats;
    public Dictionary<string, int> selectedSkills;
    public Dictionary<string, Dictionary<int, int>> additiveBuffs;
    public Dictionary<string, Dictionary<int, int>> percentileBuffs;

    public GameObject hitParticle;
    public AudioClip hitSound;
    


    private void Awake()
    {
        if (charSheet == null)
        {
            charSheet = this.GetComponent<CharacterSheet>();
        }
        else if (charSheet != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        
      
    }

    private void Update()
    {
        
    }

    public void BuildCharacterSheet(string name, Stats stats, Dictionary<string, int> skills)
    {
        playerName = name;
        baseStats = stats;
        buffedStats = new Stats();
        derivedStats = new Stats();
        selectedSkills = skills;
        additiveBuffs = new Dictionary<string, Dictionary<int, int>>();
        percentileBuffs = new Dictionary<string, Dictionary<int, int>>();

        baseStats.UpdateStats("currentMP", baseStats.GetStats("mp"));
        baseStats.UpdateStats("currentHP", baseStats.GetStats("hp"));

    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (Player.player.isInvincible)
                return;

            Player.player.isInvincible = true;
            Player.player.invincibleTimer = Player.player.timeInvincible;

            GameManager.gm.data.playerAnimator.SetTrigger("Hit");
            GameManager.gm.data.playerAudioSource.PlayOneShot(hitSound);

            Instantiate(hitParticle, Player.player.transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }

        baseStats.UpdateStats("currentHP", Mathf.Clamp(baseStats.GetStats("currentHP") + amount, 0, baseStats.GetStats("hp")));

        if (baseStats.GetStats("hp") == 0)
        {
            GameManager.gm.refreshGui();
            Respawn();
        }

        UIHealthBar.Instance.SetValue(baseStats.GetStats("currentHP") / (float)baseStats.GetStats("hp"));
    }

    public void ChangeMP(int amount)
    {
        baseStats.UpdateStats("currentMP", Mathf.Clamp(baseStats.GetStats("currentMP") + amount, 0, baseStats.GetStats("mp")));
    }

    public void ChangeXP(int amount)
    {
        baseStats.UpdateStats("xp", baseStats.GetStats("xp") + amount);
    }

    public void ChangeAvatar(Avatar avatar)
    {
        currentAvatar = avatar;
    }

    public void AdditiveModifier(string stat, int modifierID, int value, int duration)
    {
        Dictionary<int, int> modifiersList;
        if (additiveBuffs.ContainsKey(stat))
            modifiersList = additiveBuffs[stat];
        else
            modifiersList = new Dictionary<int, int>();

        modifiersList[modifierID] = value;
        additiveBuffs[stat] = modifiersList;
        CalculateStats();
        if (duration > 0)
        {
            StartCoroutine(RemoveAdditiveBuff(stat, modifierID, duration));
        }
    }

    public void PercentileModifier(string stat, int modifierID, int value, int duration)
    {
        Dictionary<int, int> modifiersList;
        if (percentileBuffs.ContainsKey(stat))
            modifiersList = percentileBuffs[stat];
        else
            modifiersList = new Dictionary<int, int>();

        modifiersList[modifierID] = value;
        percentileBuffs[stat] = modifiersList;
        CalculateStats();
        if (duration > 0)
        {
            StartCoroutine(RemovePercentileBuff(stat, modifierID, duration));
        }

    }

    public void CalculateStats()
    {
        ApplyAdditiveModifiers();
        ApplyPercentileModifiers();
        baseStats.UpdateStats("level", (Mathf.FloorToInt(50 + Mathf.Sqrt(625 + 100 + baseStats.GetStats("xp"))) / 100));
        baseStats.UpdateStats("hp", buffedStats.GetStats("defense") + (2 * buffedStats.GetStats("level")));
        baseStats.UpdateStats("mp", buffedStats.GetStats("magic") + (2 * buffedStats.GetStats("level")) + 1);
    }

    void ApplyAdditiveModifiers()
    {
        foreach (KeyValuePair<string, Dictionary<int, int>> stat in additiveBuffs)
        {
            int total = 0;
            foreach (KeyValuePair<int, int> buff in stat.Value)
            {
                total += buff.Value;
            }
            buffedStats.UpdateStats(stat.Key, baseStats.GetStats(stat.Key) + total);
        }
    }

    void ApplyPercentileModifiers()
    {
        foreach (KeyValuePair<string, Dictionary<int, int>> stat in percentileBuffs)
        {
            int total = 0;
            foreach (KeyValuePair<int, int> buff in stat.Value)
            {
                total *= buff.Value;
            }
            buffedStats.UpdateStats(stat.Key, baseStats.GetStats(stat.Key) + total);
        }
    }

    void Respawn()
    {
        ChangeHealth(baseStats.GetStats("hpmax"));
        transform.position = GameManager.gm.data.respawnPosition.position;
    }

    IEnumerator RemoveAdditiveBuff (string stat, int buffID, float time)
    {
        yield return new WaitForSeconds(time);
        Dictionary<int, int> modifiersList = additiveBuffs[stat];
        modifiersList.Remove(buffID);
        additiveBuffs[stat] = modifiersList;
        CalculateStats();
    }

    IEnumerator RemovePercentileBuff(string stat, int buffID, float time)
    {
        yield return new WaitForSeconds(time);
        Dictionary<int, int> modifiersList = percentileBuffs[stat];
        modifiersList.Remove(buffID);
        percentileBuffs[stat] = modifiersList;
        CalculateStats();
    }

}
