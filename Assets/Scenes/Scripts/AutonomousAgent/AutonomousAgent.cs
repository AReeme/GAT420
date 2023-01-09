using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutonomousAgent : Agent
{
    void Update()
    {
        var gameObjects = perception.GetGameObjects();
        foreach (var gameObject1 in gameObjects) 
        { 
            Debug.DrawLine(transform.position, gameObject1.transform.position);
        }
    }
}
