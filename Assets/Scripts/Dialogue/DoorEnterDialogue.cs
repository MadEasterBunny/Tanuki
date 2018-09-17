using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class DoorEnterDialogue : MonoBehaviour
{
    public Flowchart doorFlowchart;
    public static bool doorDialogue;
	
	void Update ()
    {
		if(doorDialogue)
        {
            doorFlowchart.ExecuteBlock("Door Dialogue");
        }
	}
}
