using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
	#region money
	private int money = 0;
	public void addMoney (int amount)
	{
		money += amount;
		updateMoneyLabel ();
	}

	public UILabel moneyLabel;
	private void updateMoneyLabel ()
	{
		moneyLabel.text = money.ToString ();
	}

	#endregion


	#region upgrade
	public Upgradable shipLevel;
	public Upgradable cannonLevel;
	public Upgradable monkeyLevel;
	public Upgradable boyLevel;
	

	public void UpgradeShip ()
	{
		upgrade (shipLevel);

	}

	public void UpgradeCannon ()
	{
		upgrade (cannonLevel);
		
	}

	public void UpgradeMonkey ()
	{
		upgrade (monkeyLevel);
		
	}

	public void UpgradeBoy ()
	{
		upgrade (boyLevel);
		
	}

	private void upgrade (Upgradable level)
	{
		if (level.IsUpgradable () &&
			level.UpgradePrice () <= money) {
			addMoney (-level.UpgradePrice ());
			level.Upgrade ();
		}
	}

	#endregion upgrade

	void Start ()
	{
		updateMoneyLabel ();
	}

}
