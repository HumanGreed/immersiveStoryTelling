using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private GameObject triggerNPC;
    private bool trigger;
    public GameObject npcText;

    private void Update()
    {
        if (trigger)
        {
            Debug.Log("Player is near " + triggerNPC);
            npcText.SetActive(true);
            // if close enought execute whats in the if-statement.
            if (Input.GetKey(KeyCode.E))
            {
                
            }
        }
        else
        {
            npcText.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Player detection next to NPC
        if(other.tag == "NPC")
        {
            trigger = true;
            triggerNPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Player detection not next to NPC
        if (other.tag == "NPC")
        {
            trigger = false;
            triggerNPC = null;
        }
    }
}


