using UnityEngine;
using System.Collections;

public class Status : MonoBehaviour
{
	public int money = 0;
	public void AddMoney (int amount)
	{
		money += amount;
	}


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
			AddMoney (-level.UpgradePrice ());
			level.Upgrade ();
		}
	}

	#endregion upgrade
}
