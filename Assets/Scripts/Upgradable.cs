using UnityEngine;
using System.Collections;

public class Upgradable : MonoBehaviour
{
	public int[] nextLevelPrice;
	public int CurLevel = 1;
		
	private Status status;

	void Awake ()
	{
		status = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Status> ();
	}

	public int MaxLevel ()
	{
		return nextLevelPrice.Length + 1;
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
		if (IsUpgradable () && IsAffordable ()) {
			status.money -= UpgradePrice ();

			CurLevel += 1;
			gameObject.SendMessage ("Upgrade", CurLevel);
		}
	}

	public bool IsUpgradable ()
	{
		return (CurLevel < MaxLevel ());
	}

	public bool IsAffordable ()
	{
		return (UpgradePrice () <= status.money);
	}
}
