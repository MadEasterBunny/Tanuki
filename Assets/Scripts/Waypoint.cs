﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    protected float drawRadius = 1f;

	// Use this for initialization
	void Start ()
    {
         
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, drawRadius);
    }
}
