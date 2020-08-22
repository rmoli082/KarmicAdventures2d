using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharSheetWrapper 
{
    public string playerName;
    public AvatarSave currentAvatar;
    public Stats baseStats;
    public Stats buffedStats;
    public Stats derivedStats;
    public Dictionary<string, int> selectedSkills;
    public Dictionary<string, Dictionary<int, int>> additiveBuffs;
    public Dictionary<string, Dictionary<int, int>> percentileBuffs;


    public CharSheetWrapper (CharacterSheet charSheet)
    {
        this.playerName = charSheet.playerName;
        this.currentAvatar = new AvatarSave(CharacterSheet.charSheet.GetAvatar());
        this.baseStats = charSheet.baseStats;
        this.buffedStats = charSheet.buffedStats;
        this.derivedStats = charSheet.secondaryStats;
        this.selectedSkills = charSheet.selectedSkills;
        this.additiveBuffs = charSheet.additiveBuffs;
        this.percentileBuffs = charSheet.percentileBuffs;
    }
}
