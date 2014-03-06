using UnityEngine;
using System.Collections;

public class Upgradable : MonoBehaviour
{
	public int[] nextGradePrice;
	public int CurGrade = 1;

	public int MaxGrade ()
	{
		return nextGradePrice.Length;
	}

	public int UpgradePrice ()
	{
		if (IsUpgradable ()) {
			return nextGradePrice [CurGrade - 1];
		} else {
			return 0;
		}
	}

	public void Upgrade ()
	{
		if (IsUpgradable ()) {
			CurGrade += 1;
		}
	}

	public bool IsUpgradable ()
	{
		return (CurGrade < MaxGrade ());
	}
	

}
