using UnityEngine;
using System.Collections;

public class WaterBande : MonoBehaviour {

    public WaterBande next;
    private AudioSource[] audios;

    void Start()
    {
        audios = GetComponentsInChildren<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
            if(next != null)
                next.Activate();
            Desactivate();
        }
    }

    public void Desactivate()
    {
        for(int i=0; i<audios.Length; i++)
        {
            audios[i].Stop();
        }
    }

    public void Activate()
    {
        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].Play();
        }
    }
}
