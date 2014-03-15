using UnityEngine;
using System.Collections;

public class UIUpgradeButton : MonoBehaviour
{
	public Upgradable upgradable;
	private UILabel label;
	private UIButton button;

	private int level = 0;
		
	void Awake ()
	{
		label = GetComponentInChildren<UILabel> ();
		button = GetComponentInChildren<UIButton> ();
	}

	void Update ()
	{
		if (level != upgradable.CurLevel) {
			level = upgradable.CurLevel;
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
