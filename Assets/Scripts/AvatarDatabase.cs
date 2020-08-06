using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarDatabase : MonoBehaviour
{
    public static AvatarDatabase avatarDb;

    public List<Avatar> avatarDatabase;

    void Awake()
    {
        if (avatarDb == null)
        {
            avatarDb = this.GetComponent<AvatarDatabase>();
        }
        else if (avatarDb != this)
        {
            Destroy(gameObject);
        }

        avatarDatabase = new List<Avatar>(Resources.LoadAll<Avatar>("Avatars"));
    }

    public Avatar GetAvatarById(int id)
    {
        foreach (Avatar avatar in avatarDatabase)
        {
            if (avatar.avatarID == id)
            {
                return avatar;
            }
        }

        return null;
    }
}
