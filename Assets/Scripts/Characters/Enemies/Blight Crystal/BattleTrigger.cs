using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BlightCrystal blightCrystal = GameObject.FindGameObjectWithTag("BlightCrystal").GetComponent<BlightCrystal>();
            blightCrystal.battleTrigger = true;
            SceneData data = GameObject.FindGameObjectWithTag("SceneData").GetComponent<SceneData>();
            data.respawnPosition = blightCrystal.respawnPoint.transform;
        }
    }
}
