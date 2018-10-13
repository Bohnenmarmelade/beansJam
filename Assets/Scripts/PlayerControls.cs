﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float destinationX;
    private float destinationY;
    private float destinationZ;

    public float forceScaleFactor = 7;

    public float laneDistance;
    public int lane = 0;


    private Animator animator;
    private Rigidbody2D rb2d;

    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destinationX = 0f;
        destinationY = 0f;
        destinationZ = 0f;
    } 

    // Update is called once per frame
    void Update(){
        Vector3 force = new Vector3(
            destinationX - transform.position.x, 
            destinationY - transform.position.y,
            destinationZ - transform.position.z);

        rb2d.AddForce(force * forceScaleFactor);
  
        if (Input.GetKeyDown(KeyCode.RightArrow))
            IncreaseLane();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            DecreaseLane();

    }

    public void IncreaseLane(){
        if (lane < 1 && animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animator.SetTrigger("TurnRightTrigger");
            lane++;
            destinationX = lane * laneDistance;
        }
    }

    public void DecreaseLane(){
        if (lane > -1 && animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            animator.SetTrigger("TurnLeftTrigger");
            lane--;
            destinationX = lane * laneDistance;
        }
    }
}
