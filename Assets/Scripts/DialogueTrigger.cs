using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool triggerOnEnter = false;
	public Dialogue dialogue;

    private bool triggered = false;

	public void TriggerDialogue ()
	{
        if (!triggered)
        {
            triggered = true;
		    FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
        }
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
            TriggerDialogue();
    }
}
