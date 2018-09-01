using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCutscene : MonoBehaviour
{
    //public Animator animator;
    private GameObject player;

    public GameObject cam1;
    //public GameObject cam2;

	
	void Start ()
    {
        //animator = GetComponent<Animator>();
        player = PlayerManager.instance.player.gameObject;
	}
	
	
	void Update ()
    {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            //cam1.SetActive(false);
            //cam2.SetActive(true);
            StartCoroutine("DogAnimation");
            //cam2.SetActive(false);
            //cam1.SetActive(true);
        }
    }

    IEnumerator DogAnimation()
    {
        cam1.SetActive(false);
        yield return new WaitForSeconds(2f);
        cam1.SetActive(true);
        /*animator.enabled = true;
        yield return new WaitForSeconds(1f);
        animator.enabled = false;*/
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
