using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private GameObject player;
    public int health = 1;
    //private bool isRespawaning;
    private Vector3 respawnPoint;

	// Use this for initialization
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
        respawnPoint = player.transform.position;
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
            this.gameObject.SetActive(false);
            Invoke("Respawn", 3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAttack enemy = collision.collider.gameObject.GetComponent <EnemyAttack> ();
        CollidedWithEnemy(enemy);
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Tutorial");
    }

    void Respawn()
    {
        player.transform.position = respawnPoint;
        health = 1;
        this.gameObject.SetActive(true);
    }
}
