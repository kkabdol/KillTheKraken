using UnityEngine;
using System.Collections;

public class Boy : MonoBehaviour
{
	public float coolingPower = 20f;

	private Cannon cannon;

	void Awake ()
	{
		cannon = GameObject.FindGameObjectWithTag (Tags.cannon).GetComponent<Cannon> ();
	}

	void Update ()
	{
		cannon.Cooldown (coolingPower * Time.deltaTime);
	}

	#region upgrade
	private float[] coolingPowerList = {
		22f,
		24f,
		26f,
		28f,
		30f,
		32f,
		34f,
		36f,
	};

	public void LevelUp (int level)
	{
		if (level >= 2 || level < coolingPowerList.Length) {
			coolingPower = coolingPowerList [level - 2];
		}
	}
	#endregion
}
