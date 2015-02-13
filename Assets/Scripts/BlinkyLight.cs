using UnityEngine;
using System.Collections;
using Uniduino;

public class BlinkyLight : MonoBehaviour {
	public Arduino arduino;
	
	public int pin = 2;
	public int pinValue;
	public int testLed = 13;
	
	void Start () {
		arduino = Arduino.global;
		arduino.Setup(ConfigurePins);
		StartCoroutine(BlinkLoop());
	}
	
	void ConfigurePins() {
		arduino.pinMode(13, PinMode.OUTPUT);
	}
	
	IEnumerator BlinkLoop() {
		while(true) {  
			arduino.digitalWrite(13, Arduino.HIGH); // led ON
			yield return new WaitForSeconds(1);
			arduino.digitalWrite(13, Arduino.LOW); // led OFF
			yield return new WaitForSeconds(1);
		}          
	}
}
