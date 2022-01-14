using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BEs.Tutorials.Movement._2D;



public class PlayerMove : PlayerMovement
{
    [Header("Ability Bools")]
    [SerializeField] public bool attcke = false;
    [SerializeField] public bool TopDownMove;

    [SerializeField] public float DashSpeed;
    [SerializeField] bool startnow;

    public bool start(bool now)
    {
        startnow = now;
        return now;
    }


    // Use this for initialization
    void Start()
    {
        start(true);
        attcke = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (startnow == true)
        {
            if (TopDownMove == false)
            {
                movement();
                WallJump();
            }
            else
            {
                TopDownMovement();
            }
        }
        //jump(); //player can jump

    }
}