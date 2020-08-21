using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlandEnemyTrap : MonoBehaviour
{
    public enum MotionDirections {Horizontal, Vertical}
    public enum Levels {EnemyA}
    public MotionDirections motionDirection = MotionDirections.Horizontal;
    public float motionMagnitude = 0.02f;
    public Levels loadLevel = Levels.EnemyA;

    // Update is called once per frame
    void Update()
    {
        switch (motionDirection)
        {
            case MotionDirections.Horizontal:
                gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
            case MotionDirections.Vertical:
                gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
                break;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.gm.EnterSubArea(loadLevel.ToString());
            Destroy(this);
        }
        
    }
}
