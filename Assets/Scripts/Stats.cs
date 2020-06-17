using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
    public Dictionary<string, int> stats;
    public Dictionary<int, Stats> modifiers;

    public Stats(Dictionary<string, int> statsList)
    {
        this.stats = statsList;
        this.modifiers = new Dictionary<int, Stats>();
    }

    public void AddModifier(int modifierID, Stats modifierList)
    {
        modifiers.Add(modifierID, modifierList);
    }

    public int GetStats(string statName)
    {
        int stat = stats[statName];
        if (modifiers.Count > 0)
        {
            foreach (KeyValuePair<int, Stats> keypair in modifiers)
            {
                foreach (KeyValuePair<string, int> modifier in keypair.Value.stats)
                {
                    if (modifier.Key == statName)
                    {
                        stat += modifier.Value;
                    }
                }
            }
        }

        return stat;
    }

}
