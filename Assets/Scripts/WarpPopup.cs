using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPopup : MonoBehaviour
{
    public static string SPIRIT = "SpiritRealm";
    public static string DEMON = "DemonRealm";
    // Start is called before the first frame update
    public void Spirit()
    {
        GameManager.gm.EnterSubArea(SPIRIT);
    }

    public void Demon()
    {
        GameManager.gm.EnterSubArea(DEMON);
    }
}
