using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEasy : MonoBehaviour {
	public float targetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	public Transform player;
	Rigidbody therigidbody;



	// Use this for initialization
	void Start () {

		therigidbody = GetComponent<Rigidbody> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		targetDistance = Vector3.Distance (player.position, transform.position);
		if (targetDistance < enemyLookDistance) {
			lookAtPlayer ();
		}
		if (targetDistance < attackDistance) {
			attack ();
		
		}
		
	}

	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * damping);
	}

	void attack(){
		therigidbody.AddForce (transform.forward * enemyMovementSpeed);
	}
}
