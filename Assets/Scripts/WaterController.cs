using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour {
	
	public int attackDamage = 100;

	GameObject player;
	PlayerHealth playerHealth;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
		
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == player)
		{
			Attack ();
		}
	}		

	void Attack ()
	{
		playerHealth.TakeDamage (attackDamage);
	}
}
