using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Warp Crystal", menuName = "Items/Warp Stone")]
public class WarpStone : Items
{
    public string locationName;
    public override void Use()
    {
        if (GameManager.gm.GetCurrentLocation().Equals(locationName))
        { 
            Inventory.inventory.RemoveItem(this);
            GameManager.gm.data.warpPopup.SetActive(true);
        }
    }
}
