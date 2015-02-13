using UnityEngine;
using System.Collections;

public class SafePlate : MonoBehaviour {

    private PlayerStats ps;
    public GameObject nonChar;

    void Awake()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ps.FrogSaved();
            GetComponent<AudioSource>().enabled = false;
            Instantiate(nonChar, transform.position, Quaternion.identity);
        }
    }
}
