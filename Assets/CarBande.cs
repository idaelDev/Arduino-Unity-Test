using UnityEngine;
using System.Collections;

public class CarBande : MonoBehaviour {

    public GameObject nextBande;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Trigger");
            if(nextBande != null)
                nextBande.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
