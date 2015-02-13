using UnityEngine;
using System.Collections;

public class Frontiere : MonoBehaviour {

    public float maxTime = 1f;
    public float maxDistance = 6.5f;
    private float time;
    private float timer = 0f;
    private Transform player;
    private AudioSource audio;

	// Use this for initialization
	void Start () {
        time = maxTime;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); ;
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float distance = Mathf.Abs(transform.position.x - player.position.x);
        if(distance < maxDistance)
        {
            time = (distance * maxTime) / maxDistance;
            if(timer > time)
            {
                if(!audio.isPlaying)
                {
                    audio.Play();
                    timer = 0f;
                }
            }
        }
	}
}
