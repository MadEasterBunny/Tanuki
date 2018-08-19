using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;

    public Transform targetTransform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Attack(PlayerHealth player)
    {
        player.health -= this.damage;
        //Destroy(this.gameObject);
    }   
}
