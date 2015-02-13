using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	private PlayerStats player;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			player.LooseLife();
		}
	}
}
