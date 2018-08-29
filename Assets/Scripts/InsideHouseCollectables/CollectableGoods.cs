using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableGoods : MonoBehaviour
{
    public Text goodsText;
    private int stolenGoods;
	
	void Start ()
    {
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
            stolenGoods++;
            goodsText.text = "盗んだ物の数：" + stolenGoods.ToString();
            Destroy(this.gameObject);
        }
    }
}
