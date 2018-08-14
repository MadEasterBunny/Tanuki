﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = 0.1f;

    Animator animator;
    NavMeshAgent agent;
    bool hiding;

    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //player = GetComponent<GameObject>();
        hiding = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);

        if (player.layer == 10)
        {
            hiding = true;
        }
        else
        {
            hiding = false;
        }

        if(hiding == true)
        {
            animator.SetBool("hiding", true);
        }

        if(hiding == false)
        {
            animator.SetBool("hiding", false);
        }
	}
}
