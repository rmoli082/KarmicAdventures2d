﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
   void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
