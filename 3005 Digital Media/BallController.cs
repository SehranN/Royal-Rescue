using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    //speed of the ball
    public float speed = 3.5F;
    //the initial direction of the ball
    private Vector2 spawnDir;
    //ball's components

    Rigidbody2D rig2D;
    // Use this for initialization
    void Start()
    {
        //setting balls Rigidbody 2D
        rig2D = this.gameObject.GetComponent<Rigidbody2D>();
        //generating random number based on possible initial directions
        int rand = Random.Range(1, 4);
        //setting initial direction
        if (rand == 1)
        {
        spawnDir = new Vector2(1, 1);
        }
        else if (rand == 2)
        {
        spawnDir = new Vector2(1, -1);
        }
        else if (rand == 3)
        {
        spawnDir = new Vector2(-1, -1);
        }
        else if (rand == 4)
        {
        spawnDir = new Vector2(-1, 1);
        }
        //moving ball in initial direction and adding speed
        rig2D.velocity = (spawnDir * speed);
    }
}