using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;
    public Image CharacterImage;

	public Animator animator;

    private GameObject player;

	private Queue<string> sentences;

	void Start ()
	{
		sentences = new Queue<string> ();
        SetPlayer();
	}

    void SetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	public void StartDialogue (Dialogue dialogue)
	{
        if(!player)
        {
            SetPlayer();
        }
        player.GetComponent<Player_Move_Prot>().canMove = false;
        player.GetComponent<Animator>().SetBool("isRunning", false);

		animator.SetBool ("isOpen", true);
		nameText.text = dialogue.name;
        CharacterImage.sprite = dialogue.characterSprite;

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}
		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}


	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue ()
	{
		animator.SetBool ("isOpen", false);
        if(player)
        {
            player.GetComponent<Player_Move_Prot>().canMove = true;
        }
	}
}
