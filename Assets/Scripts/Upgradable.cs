using UnityEngine;
using System.Collections;

public class Upgradable : MonoBehaviour
{
	public int[] nextLevelPrice;
	public int CurLevel = 1;

	public int MaxLevel ()
	{
		return nextLevelPrice.Length;
	}

	public int UpgradePrice ()
	{
		if (IsUpgradable ()) {
			return nextLevelPrice [CurLevel - 1];
		} else {
			return 0;
		}
	}

	public void Upgrade ()
	{
		if (IsUpgradable ()) {
			CurLevel += 1;
			gameObject.SendMessage ("Upgrade", CurLevel);
		}
	}

	public bool IsUpgradable ()
	{
		return (CurLevel < MaxLevel ());
	}
	

}
