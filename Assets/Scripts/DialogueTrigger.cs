using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // If dialogue is triggered when player enters a certain area
    public bool triggerOnEnter = false;
    // If dialogue is triggered when player jumps up into an object
    public bool triggerOnCollision = false;
    // If the dialogue should only be triggerable once
    public bool isOneTimeTrigger = false;

	public Dialogue dialogue;

    private bool triggered = false;

    public void TriggerDialogue()
    {
        if (!triggered || !isOneTimeTrigger)
        {
            triggered = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (triggerOnCollision && coll.gameObject.tag == "Player")
            if (Vector3.Dot(coll.contacts[0].normal, Vector3.up) > 0.5)
                TriggerDialogue();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && triggerOnEnter)
            TriggerDialogue();
    }
}
