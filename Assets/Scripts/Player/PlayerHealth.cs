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

    //public Image fadeScreen;
    //private bool fadeOut;
    //private bool fadeIn;
    //public float fadeSpeed;
    //public float waitForFade;


	// Use this for initialization
	void Start ()
    {
        player = PlayerManager.instance.player.gameObject;
        respawnPoint = player.transform.position;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        deathEffect.transform.position = player.transform.position;

        /*if(fadeOut)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                fadeOut = false;
            }
        }

        if (fadeIn)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0f)
            {
                fadeIn = false;
            }
        }*/
    }

    void CollidedWithEnemy(EnemyAttack enemy)
    {
        enemy.Attack(this);
        if(health <= 0)
        {
            PlayerDead();
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
        //fadeIn = true;
    }

    void PlayerDead()
    { 
        deathEffect.Play();
        this.gameObject.SetActive(false);
        //fadeOut = true;
    }

    /*IEnumerator RespawnCo()
    {
        deathEffect.Play();
        this.gameObject.SetActive(false);
        fadeOut = true;

        yield return new WaitForSeconds(respawnLength);

        fadeIn = true;

        this.gameObject.SetActive(true);
        player.transform.position = respawnPoint;
        health = 1;
    }*/
}
