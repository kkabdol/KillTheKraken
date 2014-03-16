using UnityEngine;
using System.Collections;

public class TestBase : MonoBehaviour
{
	public GameObject upgradePanel;
	public GameObject controlPanel;
	private Upgradable[] upgradables;


	void Awake ()
	{
		upgradables = new Upgradable[4];
		upgradables [0] = GameObject.FindGameObjectWithTag (Tags.ship).GetComponent<Upgradable> ();
		upgradables [1] = GameObject.FindGameObjectWithTag (Tags.monkey).GetComponent<Upgradable> ();
		upgradables [2] = GameObject.FindGameObjectWithTag (Tags.boy).GetComponent<Upgradable> ();
		upgradables [3] = GameObject.FindGameObjectWithTag (Tags.cannon).GetComponent<Upgradable> ();
	}

	void Start ()
	{
		SaveDefaultPrice ();
	}

	#region upgrade

	private bool isUpgradePanelTurnedOn = false;
	public void switchTestBase ()
	{
		if (isUpgradePanelTurnedOn == false) {
			isUpgradePanelTurnedOn = true;
			
			upgradePanel.SetActive (true);
			controlPanel.SetActive (false);
		} else {
			isUpgradePanelTurnedOn = false;
			
			upgradePanel.SetActive (false);
			controlPanel.SetActive (true);
		}
	}
	#endregion


	#region price cheat
	private int[,] defaultPrices;

	private bool isPriceCheatTurnedOn = false;
	public void switchPriceCheat ()
	{
		if (isPriceCheatTurnedOn == false) {
			isPriceCheatTurnedOn = true;

			for (int i=0; i<upgradables.Length; ++i) {
				for (int j=0; j<upgradables[i].nextLevelPrice.Length; ++j) {
					upgradables [i].nextLevelPrice [j] = 1;
				}
			}

		} else {
			isPriceCheatTurnedOn = false;
			
			for (int i=0; i<upgradables.Length; ++i) {
				for (int j=0; j<upgradables[i].nextLevelPrice.Length; ++j) {
					upgradables [i].nextLevelPrice [j] = defaultPrices [i, j];
				}
			}
		}
	}

	private void SaveDefaultPrice ()
	{
		if (defaultPrices == null) {
			defaultPrices = new int[upgradables.Length, upgradables [0].nextLevelPrice.Length];
		}

		for (int i=0; i<upgradables.Length; ++i) {
			for (int j=0; j<upgradables[i].nextLevelPrice.Length; ++j) {
				defaultPrices [i, j] = upgradables [i].nextLevelPrice [j];
			}
		}
	}
	#endregion

}
