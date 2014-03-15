using UnityEngine;
using System.Collections;

public class UIMoneyLabel : MonoBehaviour
{
	private int money = -1;
	private UILabel moneyLabel;
	private Status status;

	void Awake ()
	{
		moneyLabel = GetComponent<UILabel> ();
		status = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Status> ();
	}


	void Update ()
	{
		if (money != status.money) {
			money = status.money;
			moneyLabel.text = money.ToString ();
		}
	}

}
