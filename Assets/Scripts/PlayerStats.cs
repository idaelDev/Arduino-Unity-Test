using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public GameObject bande1;
    public GameObject bande2;
    public GameObject bande3;
	public Text lifeText;
    public Text endText;
    public Text frogLeftText;
	public int initLife = 2;
    public int frogToSave = 6;
    private int frogLeft = 6;
	private int lifeLeft;
	
	private CharController charController;
	private Vector3 initPosition;
	private string text = "Vie : ";
    private string winText = "Bravo ! Vous avez sauvé toutes les grenouilles";
    private string gameOverText = "Game Over";
    private string frogLeftString = " Grenouilles";

	void Awake()
	{
		charController = GetComponent<CharController>();
		lifeLeft = initLife;
		initPosition = gameObject.transform.position;
		lifeText.text = text + initLife;
        frogLeftText.text = frogLeft + frogLeftString;
        endText.enabled = false;
	}

	public void LooseLife()
	{
		lifeLeft--;
		lifeText.text = text + lifeLeft;
		if(lifeLeft <=0)
		{
            Death();
		}

        InitLevel();
	}

    public void FrogSaved()
    {
        frogLeft--;
        frogLeftText.text = frogLeft + frogLeftString;
        InitLevel();
        if(frogLeft <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        //charController.enabled = false;
        endText.text = winText;
        endText.color = Color.green;
        endText.enabled = true;
    }

	void Death()
	{
        //charController.enabled = false;
        endText.text = gameOverText;
        endText.color = Color.red;
        endText.enabled = true;
	}

    void InitLevel()
    {
        gameObject.transform.position = initPosition;
        gameObject.transform.SetParent(null);
        bande1.SetActive(true);
        bande2.SetActive(false);
        bande3.SetActive(false);
    }
}
