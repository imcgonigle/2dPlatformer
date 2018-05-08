using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
	public Animator animator;
	GameObject player;

	void Start ()
	{
        GetPlayer();
	}

	public void ToggleQuiz ()
	{
        bool isOpen = animator.GetBool ("isOpen");
        isOpen = !isOpen;

		animator.SetBool ("isOpen", isOpen);

        if (!player)
        {
            GetPlayer();
        }
		player.GetComponent<Player_Move_Prot> ().canMove = !isOpen;
	}

    void GetPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
