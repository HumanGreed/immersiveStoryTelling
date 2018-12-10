using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcController : MonoBehaviour {

    private GameObject triggerNPC;
    private bool trigger;
    public GameObject player;
    public GameObject npcText;
    public Text col;
    public Dialogue dialogue;

    private void Update()
    {
        if (trigger)
        {
            npcText.SetActive(true);
            col.text = "Collision: Detected";
            // if close enought execute whats in the if-statement.
            if (Input.GetKey(KeyCode.E))
            {
                FindObjectOfType<DialogueTrigger>().triggerDialogue();
                
            }
        }
        else
        {
            npcText.SetActive(false);
            col.text = "Collision: Not Detected";
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


