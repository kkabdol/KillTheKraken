using UnityEngine;
using System.Collections;

public class TestBase : MonoBehaviour
{
	// real ocean look and feel test	
	public GameObject realBackground;
	private bool isRealBackgroundTurnedOn = false;
	public void switchRealBackground ()
	{
		if (isRealBackgroundTurnedOn == true) {
			realBackground.SetActive (false);
			isRealBackgroundTurnedOn = false;
		} else {
			realBackground.SetActive (true);
			isRealBackgroundTurnedOn = true;
		}
	}
	
}
