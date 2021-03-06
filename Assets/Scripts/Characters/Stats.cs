﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stats 
{
    public Dictionary<string, int> stats;

    public Stats() 
    {
        stats = new Dictionary<string, int>();
    }

    public Stats(Dictionary<string, int> statsList)
    {
        this.stats = statsList;
    }

    public int GetStats(string statName)
    {
        if (stats.ContainsKey(statName))
            return stats[statName];
        else
            return -1;
    }

    public Dictionary<string, int> GetAllStats()
    {
        return stats;
    }

    public void UpdateStats(string statName, int value)
    {
        stats[statName] = value;    
    }

}
