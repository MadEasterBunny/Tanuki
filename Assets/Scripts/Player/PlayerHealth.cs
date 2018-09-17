using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private GameObject player;
    public int health = 1;
    
    private Vector3 respawnPoint;
    public float respawnLength;

    public ParticleSystem deathEffect;

    public AudioSource audioSource;
    public AudioClip deathSoundDog;
    public AudioClip deathSoundMan;

	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
        respawnPoint = player.transform.position;
        //audioSource = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        deathEffect.transform.position = player.transform.position;
    }

    void CollidedWithEnemy(EnemyAttack enemy)
    {
        enemy.Attack(this);
        if(health <= 0)
        {
            if (enemy.tag == "Dog")
                PlayerDeadDog();
            else
                PlayerDeadMan();
            Invoke("Respawn", 3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyAttack enemy = collision.collider.gameObject.GetComponent <EnemyAttack> ();
        CollidedWithEnemy(enemy);
    }

    void Respawn()
    {
        player.transform.position = respawnPoint;
        health = 1;
        this.gameObject.SetActive(true);
        player.tag = "Player";
    }

    void PlayerDeadDog()
    { 
        deathEffect.Play();
        audioSource.PlayOneShot(deathSoundDog, 0.7f);
        this.gameObject.SetActive(false);
    }

    void PlayerDeadMan()
    {
        deathEffect.Play();
        audioSource.PlayOneShot(deathSoundMan, 0.7f);
        this.gameObject.SetActive(false);
    }
}
