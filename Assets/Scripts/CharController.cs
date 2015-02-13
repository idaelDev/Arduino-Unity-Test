using UnityEngine;
using System.Collections;
using Uniduino;

public class CharController : MonoBehaviour {
	public Arduino arduino;
	
	public int upPin = 4;
	public int upPinValue;
	public int rightPin = 7;
	public int rightPinValue;
	public int leftPin = 2;
	public int leftPinValue;
	public int testLed = 13;

	public bool keyboardControl = false;
	// Use this for initialization
	void Start () {
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);
	}
	
	// Update is called once per frame
	void Update () {
		if(keyboardControl)
			KeyboardController();
		else
			ArduinoController();
//		transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
	}

	void ArduinoController()
	{	
		if(upPinValue == 0)
		{
			upPinValue = arduino.digitalRead(upPin);
			gameObject.transform.Translate(new Vector3(0,upPinValue, 0));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		else
			upPinValue = arduino.digitalRead(upPin);
		if(rightPinValue == 0)
		{
			rightPinValue = arduino.digitalRead(rightPin);
			gameObject.transform.Translate(new Vector3(-rightPinValue,0, 0));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		else
			rightPinValue = arduino.digitalRead(rightPin);
		if(leftPinValue == 0)
		{
			leftPinValue = arduino.digitalRead(leftPin);
			gameObject.transform.Translate(new Vector3(leftPinValue,0, 0));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		else
			leftPinValue = arduino.digitalRead(leftPin);
	}

	void KeyboardController()
	{
		
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			gameObject.transform.Translate(new Vector3(0f,1f,0f));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			gameObject.transform.Translate(new Vector3(0f,-1f,0f));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			gameObject.transform.Translate(new Vector3(1f,0f,0f));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			gameObject.transform.Translate(new Vector3(-1f,0f,0f));
			transform.position = new Vector3((int)transform.position.x, transform.position.y, transform.position.z);
		}
	}

	void ConfigurePins( )
	{
		arduino.pinMode(upPin, PinMode.INPUT);
		arduino.reportDigital((byte)(upPin/8), 1);
		arduino.pinMode(rightPin, PinMode.INPUT);
		arduino.reportDigital((byte)(rightPin/8), 1);
		arduino.pinMode(leftPin, PinMode.INPUT);
		arduino.reportDigital((byte)(leftPin/8), 1);
		// set the pin mode for the test LED on your board, pin 13 on an Arduino Uno
		arduino.pinMode(testLed, PinMode.OUTPUT);
	}
}
