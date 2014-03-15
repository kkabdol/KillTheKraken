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

}
