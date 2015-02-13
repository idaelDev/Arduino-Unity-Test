using UnityEngine;
using System.Collections;

public class PlateformMovement : MonoBehaviour {

	public bool right = true;
	public float speed = 5f;
	private Rigidbody2D[] childs;
	private Plateform[] plateforms;
	public bool movePlayer = false;
	private Rigidbody2D player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
		childs = GetComponentsInChildren<Rigidbody2D>();
		plateforms = GetComponentsInChildren<Plateform>() ;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = (right)? Vector3.right : -Vector3.right;
		for(int i=0; i<childs.Length; i++)
		{
			childs[i].MovePosition(childs[i].gameObject.transform.position + direction * speed * Time.deltaTime);
		}
		if(movePlayer)
		{
			player.MovePosition(player.gameObject.transform.position + direction * speed * Time.deltaTime);
		}
	}



	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Obstacle")
		{
			Debug.Log("Trigger");
			Vector3 newPos = other.gameObject.transform.position;
			newPos.x = -newPos.x;
			other.gameObject.transform.position = newPos;
		}
		if(other.gameObject.tag == "Player")
			movePlayer = false;

	}
}
