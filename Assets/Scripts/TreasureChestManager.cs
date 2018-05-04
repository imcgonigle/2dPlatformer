using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestManager : MonoBehaviour {
    public Animator animator;

	void ToggleTreasureChest()
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
