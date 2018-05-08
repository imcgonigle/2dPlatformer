using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prot : MonoBehaviour
{

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	public float distanceToBottomOfPlayer = 0.78f;
	public bool canMove = true;

	private float moveX;
	private bool isGrounded = false;

	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidBody;

	void Start ()
	{
		// Instantiate componenets.
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		PlayerMove (); // Move the player
		PlayerRaycast (); // Check for collisions
	}

	void PlayerMove ()
	{
		// CONTROLS
		if (canMove) {
			moveX = Input.GetAxis ("Horizontal"); // Float from -1 and 1

			if (Input.GetButtonDown ("Jump") && isGrounded) {
				Jump ();
			}

			// ANIMATIONS
			animator.SetBool ("isRunning", moveX != 0); // Set isRunning to true if the player is moving.

			// Set the players direction
			if (moveX != 0) {
				spriteRenderer.flipX = moveX < 0.0f;
			}

			// PHYSICS
			rigidBody.velocity = new Vector2 (moveX * playerSpeed, rigidBody.velocity.y);
		}
	}

	/**
	 * If player is on the ground make them jump into
	 * the air.
	 **/
	void Jump ()
	{
		isGrounded = false; // Set isGrounded to false so player can't double jump.
		rigidBody.AddForce (Vector2.up * playerJumpPower);
	}


	/**
	 * Check to see if the player has run into other gameobjects.
	 * - BreakableBoxes
	 * - Enemies
	 **/
	void PlayerRaycast ()
	{
		/**
		 * Check to see if player jumped into
		 * a breakable box. If so, destroy the box.
		 **/
		RaycastHit2D rayUp = Physics2D.Raycast (transform.position, Vector2.up);
		if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomOfPlayer) {
			if (rayUp.collider.tag == "breakable") {
				Destroy (rayUp.collider.gameObject);
			}
		}

		/**
		 * Check to see if the player landed on an
		 * enemy. If so, Destroy the emeny.
		 * */
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

	/**
	 * Disables player controls. Used whenever there's
	 * dialogue or a quiz open.
	 */
	public void DisableMovement ()
	{
		canMove = false;
	}

	/**
	 * Enables player movement. Used by dialogue
	 * and quiz manager after their UI closes.
	 */
	public void EnableMovement ()
	{
		canMove = true;
	}
}
