using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopDialog : MonoBehaviour
{
    public GameObject dialogBox;

    void OnTriggerEnter2D (Collider2D other)
    {
        dialogBox.SetActive(true);
    }
}
