using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player player;

    public Avatar currentAvatar;
    public Dictionary<string, int> baseStats = new Dictionary<string, int>();
    public Dictionary<string, int> activeStats = new Dictionary<string, int>();
    
    void Awake()
    {
         if (player == null) {
            player = this.GetComponent<Player>();
        } 
        else if (player != this)
        {
            Destroy(gameObject);
        }
        baseStats.Add("hp", 5);
        baseStats.Add("mp", 7);
        baseStats.Add("xp", 0);
        baseStats.Add("Attack", 10);
        baseStats.Add("Defense", 10);
        baseStats.Add("Speed", 10);
        baseStats.Add("Special", 10);
        activeStats.Add("hp", 5);
        activeStats.Add("mp", 7);
        activeStats.Add("xp", 0);
        activeStats.Add("Attack", 10);
        activeStats.Add("Defense", 10);
        activeStats.Add("Speed", 10);
        activeStats.Add("Special", 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
       
    }
}
