using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
	public Animator animator;
	GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void ToggleQuiz ()
	{
		bool isOpen = animator.GetBool ("isOpen");
		player.GetComponent<Player_Move_Prot> ().canMove = !isOpen;
		animator.SetBool ("isOpen", !isOpen);
	}
}
