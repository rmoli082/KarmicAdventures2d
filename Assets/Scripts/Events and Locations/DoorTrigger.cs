﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string loadLevel;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            GameManager.gm.EnterSubArea(loadLevel);
        }
    }
}
