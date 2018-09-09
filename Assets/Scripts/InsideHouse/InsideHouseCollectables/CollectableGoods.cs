using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableGoods : MonoBehaviour
{
    public Text goodsText;
    private int stolenGoods;

    //private AudioSource pickUpSound;
    public AudioClip pickUpSoundEffect;
	
	void Start ()
    {
        //pickUpSound = GetComponent<AudioSource>();
        if(goodsText != null)
        {
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
        }
	}
	
	
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(pickUpSoundEffect, transform.position, 0.5f);
            stolenGoods++;
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
            Destroy(this.gameObject);
        }
    }
}
