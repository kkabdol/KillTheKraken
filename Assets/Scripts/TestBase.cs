using UnityEngine;
using System.Collections;

public class TestBase : MonoBehaviour
{
	public GameObject realBackground;
	public GameObject upgradePanel;
	public GameObject contorlPanel;

	private bool isTestBaseTurnedOn = false;
	public void switchTestBase ()
	{
		if (isTestBaseTurnedOn == true) {
			isTestBaseTurnedOn = false;

			realBackground.SetActive (false);
			upgradePanel.SetActive (false);
			contorlPanel.SetActive (true);
		} else {
			isTestBaseTurnedOn = true;

			realBackground.SetActive (true);
			upgradePanel.SetActive (true);
			contorlPanel.SetActive (false);
		}
	}
}
