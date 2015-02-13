using UnityEngine;
using System.Collections;

public class Plateform : MonoBehaviour {

	public int size = 2;
	public bool playerIn = false;
    //private PlateformMovement pm;

	void Awake()
	{
        //pm = GetComponentInParent<PlateformMovement>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
//			pm.movePlayer = true;
			other.gameObject.transform.SetParent(transform);
            //RoundPosition(other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.transform.SetParent(null);
		}
	}

	void RoundPosition(GameObject go)
	{
		float xAdjust = 0;
		if(size == 2)
		{
			if(go.transform.position.x >= 0)
			{
				xAdjust = 0.25f;
			}
			else
			{
				xAdjust = -0.25f;
			}
			
		}
		go.transform.localPosition = new Vector3(go.transform.localPosition.x + xAdjust , go.transform.localPosition.y, go.transform.localPosition.z);
	}

}
