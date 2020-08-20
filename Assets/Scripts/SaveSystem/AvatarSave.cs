using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
        if (avatar != null)
        {
            avatarID = avatar.avatarID;
            avatarName = avatar.avatarName;
        }
        else
        {
            avatarID = -1;
            avatarName = "none";
        }
        
    }

}
