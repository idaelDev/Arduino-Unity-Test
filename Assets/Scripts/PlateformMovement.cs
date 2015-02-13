using UnityEngine;
using System.Collections;

public class PlateformMovement : MonoBehaviour {

    public GameObject nextBande;
	public bool right = true;
	public float speed = 5f;
    public float maxX = 7f;
	private Rigidbody2D[] childs;
    //private Plateform[] plateforms;

	// Use this for initialization
	void Start () {
		childs = GetComponentsInChildren<Rigidbody2D>();
        //plateforms = GetComponentsInChildren<Plateform>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = (right)? Vector3.right : -Vector3.right;
		for(int i=0; i<childs.Length; i++)
		{
			childs[i].MovePosition(childs[i].gameObject.transform.position + direction * speed * Time.deltaTime);
            if(Mathf.Abs(childs[i].gameObject.transform.position.x) >= maxX+1)
            {
                Vector3 newPos = childs[i].gameObject.transform.position;
                newPos.x = (right) ? -maxX : maxX;
                childs[i].gameObject.transform.position = newPos;
            }
		}
	}



}
