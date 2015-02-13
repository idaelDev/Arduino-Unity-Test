using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public Text lifeText;
	public int initLife = 2;
	private int lifeLeft;
	
	private CharController charController;
	private Vector3 initPosition;
	private string text = "Vie : ";

	void Awake()
	{
		charController = GetComponent<CharController>();
		lifeLeft = initLife;
		initPosition = gameObject.transform.position;
		lifeText.text = text + initLife;
	}

	public void LooseLife()
	{
		lifeLeft--;
		lifeText.text = text + lifeLeft;
		if(lifeLeft <=0)
		{
			Death();
		}
		else
		{
			gameObject.transform.position = initPosition;
		}
	}

	void Death()
	{
		charController.enabled = false;
	}
}
