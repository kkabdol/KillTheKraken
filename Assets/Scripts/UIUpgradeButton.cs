using UnityEngine;
using System.Collections;

public class UIUpgradeButton : MonoBehaviour
{
	public Upgradable upgradable;
	private UILabel label;
	private UIButton button;

	private int level = 0;
	private int oldPrice = 0;	// for price cheat
		
	void Awake ()
	{
		label = GetComponentInChildren<UILabel> ();
		button = GetComponentInChildren<UIButton> ();
	}

	void Start ()
	{
		oldPrice = upgradable.UpgradePrice ();
	}

	void Update ()
	{
		if (level != upgradable.CurLevel ||
			oldPrice != upgradable.UpgradePrice ()) {

			level = upgradable.CurLevel;
			oldPrice = upgradable.UpgradePrice ();

			if (!upgradable.IsUpgradable ()) {
				label.text = "Max Level";
			} else {
				label.text = string.Format ("{0} -> {1}", upgradable.UpgradePrice (), level + 1);
			}
		}

		if (!button.enabled && upgradable.IsAffordable ()) {
			button.enabled = true;
		} else if (button.enabled && !upgradable.IsAffordable ()) {
			button.enabled = false;
		}
	}

	public void Upgrade ()
	{
		upgradable.Upgrade ();
	}
}
