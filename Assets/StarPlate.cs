using UnityEngine;
using System.Collections;

public class StarPlate : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
