using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;					// The speed that the player will move at.
	public float jumpForce;				// The speed the character will jump at.

	Vector3 movement;					// The vector to store the direction of the player's movement.
	Vector3 horizontalMovement;                   
	Vector3 verticalMovement;
	Animator anim;                      // Reference to the animator component.
//	CharacterController playerCharacterController;          // Reference to the player's character controller.
	Rigidbody playerRigidbody;
//	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
//	float camRayLength = 100f;          // The length of the ray from the camera into the scene.
	int jumpCharges;

	void Awake ()
	{
//		// Create a layer mask for the floor layer.
//		floorMask = LayerMask.GetMask ("Floor");

		// Set up references.
		anim = GetComponent <Animator> ();
		//playerCharacterController = GetComponent <CharacterController> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}


	void Update ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
//		float v = Input.GetAxisRaw ("Vertical");

		// Move the player around the scene.
		Move (h);

		if (Input.GetButtonDown ("Jump")) {
			Jump ();
		}
	}

	void Move (float h)
	{
		// Set the movement vector based on the axis input.
		horizontalMovement.Set (h, 0f, 0f);

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.forward = new Vector3 (-10f, 0f, 0f);
			anim.SetBool ("Idling", false);
			anim.SetBool ("UNCombatMove", true);
		} else if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			transform.forward = new Vector3 (10f, 0f, 0f);
			anim.SetBool ("Idling", false);
			anim.SetBool ("UNCombatMove", true);
		}
		else anim.SetBool ("Idling", true);

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = (horizontalMovement.normalized * speed * Time.deltaTime) + (verticalMovement.normalized * Time.deltaTime);

		// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Jump ()
	{
//			playerRigidbody.AddRelativeForce(0, jumpForce, 0, ForceMode.Impulse);
			playerRigidbody.AddForce (0, jumpForce, 0, ForceMode.Impulse);
	}
}