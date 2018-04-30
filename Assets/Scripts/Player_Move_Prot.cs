using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	private float moveX;
	public bool isGrounded = false;
	public bool isTiny = false;
	public float distanceToBottomOfPlayer = 0.78f;
	
	// Update is called once per frame
	void Update ()
	{
		PlayerMove ();
		PlayerRaycast ();
	}

	void PlayerMove ()
	{
		// CONTROLS
		moveX = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			Jump ();
		}
	
		if (Input.GetKeyDown ("up")) {
			if (isTiny) {
				gameObject.transform.localScale += new Vector3 (0.5f, 0.5f);
			} else {
				gameObject.transform.localScale += new Vector3 (-0.5f, -0.5f);
			}

			isTiny = !isTiny;
		}
		// ANIMATIONS
		// PLAYER DIRECTION
		if (moveX != 0) {
			GetComponent<Animator> ().SetBool ("isRunning", true);
		} else {
			GetComponent<Animator> ().SetBool ("isRunning", false);
		}

		// Player Direction
		if (moveX < 0.0f) {
			GetComponent<SpriteRenderer> ().flipX = true;
		} else if (moveX > 0.0f) {
			GetComponent<SpriteRenderer> ().flipX = false;
		}

		// PHYSICS
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void Jump ()
	{
		isGrounded = false;
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}

	void PlayerRaycast ()
	{
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer) {
			if (rayUp.collider.tag == "breakable") {
				Destroy (rayUp.collider.gameObject);
			}
		}

		RaycastHit2D rayDown = Physics2D.Raycast (transform.position, Vector2.down);
		if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer) {
			if (rayDown.collider.tag == "enemy") {
				GameObject.Find ("BreakableBoxAudio").GetComponent<AudioSource> ().Play ();
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
				rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
				rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
				rayDown.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 8;
				rayDown.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
				rayDown.collider.gameObject.GetComponent<Enemy_Move> ().enabled = false;

			} else {
				isGrounded = true;
			}
		}
	}
}
