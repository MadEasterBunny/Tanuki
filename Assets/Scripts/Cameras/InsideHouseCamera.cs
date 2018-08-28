using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideHouseCamera : MonoBehaviour
{
    public GameObject player;
    private float deltaZ;
    private float cameraY;
    private float cameraX;
    public float deltaY;
	
	void Start ()
    {
        deltaZ = Mathf.Abs(player.transform.position.z - transform.position.z);
        cameraY = transform.position.y;
        cameraX = transform.position.x;
	}
	
	
	void Update ()
    {
        YFollow();
        SetCameraPosition();
	}

    void SetCameraPosition()
    {
        transform.position = new Vector3(cameraX, cameraY, player.transform.position.z + deltaZ);
    }

    void YFollow()
    {
        if(player.transform.position.y < transform.position.y - deltaY)
        {
            cameraY = player.transform.position.y + deltaY;
        }
        else if(player.transform.position.y > transform.position.y + deltaY)
        {
            cameraY = player.transform.position.y - deltaY;
        }
    }
}
