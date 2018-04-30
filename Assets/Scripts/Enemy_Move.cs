using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Move : MonoBehaviour
{

	public int EnemySpeed;
	public int XMoveDirection;
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (XMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (XMoveDirection, 0) * EnemySpeed;
		if (hit.distance < 0.5f) {
			Flip ();
			if (hit.collider.tag == "Player") {
				Player_Health.playerHealth.Die ();
			}
		}
	}

	void Flip ()
	{
		XMoveDirection *= -1;
	}
}
