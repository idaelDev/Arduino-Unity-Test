using UnityEngine;
using System.Collections;
using Uniduino;

public class Servo : MonoBehaviour {
	
	public Arduino arduino;
	
	public int pin = 2;
	public int pinValue;
	public int testLed = 13;
	
	void Start( )
	{
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);
	}
	
	void ConfigurePins( )
	{
		arduino.pinMode(pin, PinMode.INPUT);
		arduino.reportDigital((byte)(pin/8), 1);
		// set the pin mode for the test LED on your board, pin 13 on an Arduino Uno
		arduino.pinMode(testLed, PinMode.OUTPUT);
	}
	
	void Update ()
	{      
		// read the value from the digital input
		pinValue = arduino.digitalRead(pin);
		// apply that value to the test LED
		arduino.digitalWrite(testLed, pinValue);
	}
}