using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLocation : MonoBehaviour
{
    public string locationName;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.OnLocationFound(locationName);
    }
}
