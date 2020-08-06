using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AvatarSave
{
    public int avatarID;
    public string avatarName;

    public AvatarSave()
    {

    }

    public AvatarSave(Avatar avatar)
    {
        avatarID = avatar.avatarID;
        avatarName = avatar.avatarName;
    }

}
