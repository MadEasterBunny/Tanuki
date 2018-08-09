﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 1;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void CollidedWithEnemy(EnemyAttack enemy)
    {
        enemy.Attack(this);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAttack enemy = collision.collider.gameObject.GetComponent <EnemyAttack> ();
        CollidedWithEnemy(enemy);
    }
}
