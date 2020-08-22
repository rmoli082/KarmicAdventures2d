using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class CharacterSheet : MonoBehaviour
{
    public static CharacterSheet charSheet;

    public enum Statistics { attack, defense, magic, special }

    public string playerName;
    public Avatar currentAvatar;
    public Stats baseStats;
    public Stats buffedStats;
    public Stats secondaryStats;
    public Dictionary<string, int> selectedSkills;
    public Dictionary<string, Dictionary<int, int>> additiveBuffs;
    public Dictionary<string, Dictionary<int, int>> percentileBuffs;

    public GameObject hitParticle;
    public AudioClip hitSound;

    public int statPoints;
    public int skillPoints;

    private string lastLevel;


    private void Awake()
    {
        if (charSheet == null)
        {
            charSheet = this.GetComponent<CharacterSheet>();
            currentAvatar = (Avatar)Resources.Load("Avatars/NoAvatar.asset");
        }
        else if (charSheet != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
       
    }

    private void Start()
    {
        GameEvents.SaveInitiated += Save;
        GameEvents.LoadInitiated += Load;
        GameEvents.XpAwarded += CheckForLevelUp;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void BuildCharacterSheet(string name, Stats stats, Dictionary<string, int> skills)
    {
        playerName = name;
        baseStats = stats;
        buffedStats = stats;
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
            Respawn();
        }

        UIHealthBar.Instance.SetHealthValue(baseStats.GetStats("currentHP") / (float)baseStats.GetStats("hp"));
    }

    public void ChangeMP(int amount)
    {
        baseStats.UpdateStats("currentMP", Mathf.Clamp(baseStats.GetStats("currentMP") + amount, 0, baseStats.GetStats("mp")));
        UIHealthBar.Instance.SetManaValue(baseStats.GetStats("currentMP") / (float)baseStats.GetStats("mp"));

        
    }

    public void ChangeXP(int amount)
    {
        baseStats.UpdateStats("xp", baseStats.GetStats("xp") + amount);
        GameEvents.OnXpAwarded();
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
        if (duration > 0)
        {
            StartCoroutine(RemoveAdditiveBuff(stat, modifierID, duration));
        }
        CalculateStats();
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
        if (duration > 0)
        {
            StartCoroutine(RemovePercentileBuff(stat, modifierID, duration));
        }
        CalculateStats();
    }

    public void CalculateStats()
    {
        ApplyAdditiveModifiers();
        ApplyPercentileModifiers();
        baseStats.UpdateStats("hp", buffedStats.GetStats("defense") + (2 * baseStats.GetStats("level")));
        baseStats.UpdateStats("mp", buffedStats.GetStats("magic") + (2 * baseStats.GetStats("level")) + 1);
    }

    public Avatar GetAvatar()
    {
        if (currentAvatar != null)
        {
            return currentAvatar;
        }
        else
        {
            return (Avatar) Resources.Load("Avatars/NoAvatar.asset");
        }
    }

    public string GetLastLevel()
    {
        return lastLevel;
    }

    public void SetLastLevel(string sceneName)
    {
        lastLevel = sceneName;
    }

    public void Respawn()
    {
        ChangeHealth(baseStats.GetStats("hp"));
        transform.position = GameManager.gm.data.respawnPosition.position;
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
                total += buff.Value;
            }
            buffedStats.UpdateStats(stat.Key, Mathf.FloorToInt(baseStats.GetStats(stat.Key) * (1 + (total/100))));
        }
    }

    public void GetStatsBonus()
    {
        Dictionary<string, int> stats = baseStats.GetAllStats();
        foreach (KeyValuePair<string, int> stat in stats)
        {
            if (System.Enum.IsDefined(typeof(Statistics), stat.Key))
                AdditiveModifier(stat.Key, 2, (stat.Value - 10) / 2, 0);
        }
        
    }

    void DoLevelUp()
    {
        GameManager.gm.data.levelUpButton.SetActive(true);
        skillPoints++;
        GameManager.gm.data.levelUpText.text = $"You have {skillPoints} skill point to spend.";

        if (baseStats.GetStats("level") % 3 == 0)
        {
            GameManager.gm.data.levelUpText.text = $"You have {statPoints} stat point and {skillPoints} skill point you can spend.";
            statPoints++;
            GameManager.gm.data.statsPanel.SetActive(true);
        }
    }

    void Save()
    {
        SaveLoad.Save<CharSheetWrapper>(new CharSheetWrapper(CharacterSheet.charSheet), "CharacterSheet");
    }

    void Load()
    {
        if (SaveLoad.SaveExists("CharacterSheet"))
        {
            CharSheetWrapper wrappedSheet = SaveLoad.Load<CharSheetWrapper>("CharacterSheet");

            playerName = wrappedSheet.playerName;
            baseStats = wrappedSheet.baseStats;
            buffedStats = wrappedSheet.buffedStats;
            secondaryStats = wrappedSheet.derivedStats;
            selectedSkills = wrappedSheet.selectedSkills;
            additiveBuffs = wrappedSheet.additiveBuffs;
            percentileBuffs = wrappedSheet.percentileBuffs;

            currentAvatar = AvatarDatabase.avatarDb.GetAvatarById(wrappedSheet.currentAvatar.avatarID);
        }
    }

    void CheckForLevelUp()
    {
        if (baseStats.GetStats("level") < Mathf.FloorToInt((50 + (Mathf.Sqrt(625 + 100 * baseStats.GetStats("xp")))) / 100))
        {
            baseStats.UpdateStats("level", Mathf.FloorToInt((50 + (Mathf.Sqrt(625 + 100 * baseStats.GetStats("xp")))) / 100));
            GameManager.gm.data.level.text = baseStats.GetStats("level").ToString();
            DoLevelUp();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameManager.gm.data.level.text = baseStats.GetStats("level").ToString();
        Debug.Log(baseStats.GetStats("level"));
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
