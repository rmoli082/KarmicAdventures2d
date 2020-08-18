using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "new Avatar", menuName = "Avatars/Avatar Form")]
public class Avatar : ScriptableObject
{
    public int avatarID;
    public string avatarName;
    public string avatarDescription;
    public Sprite avatarIcon;
    public int attackUp;
    public int defenseUp;
    public int magicUp;

}
