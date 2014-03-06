using UnityEngine;
using System.Collections;

public class TestBase : MonoBehaviour
{
	public GameObject realBackground;
	public GameObject upgradePanel;

	private bool isTestBaseTurnedOn = false;
	public void switchTestBase ()
	{
		if (isTestBaseTurnedOn == true) {
			isTestBaseTurnedOn = false;

			realBackground.SetActive (false);
			upgradePanel.SetActive (false);
		} else {
			isTestBaseTurnedOn = true;

			realBackground.SetActive (true);
			upgradePanel.SetActive (true);
		}
	}
}
