using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	private Ship ship;

	void Awake ()
	{
		ship = GameObject.FindGameObjectWithTag (Tags.ship).GetComponent<Ship> ();
	}

	#region fire
	public Transform gunpoint;
	public float flyTime = 1f;
	public Transform[] hitPoints;

	public void Fire ()
	{
		if (isRefeshing) {
			return;
		}

		Bomb bomb = ship.PopBomb ();
		if (bomb.isRedBomb) {
			consumeHitPoint (bomb.mass);
			isRefeshing = true;
			Destroy (bomb.gameObject);
			return;
		}

		iTween.Stop (bomb.gameObject);
		bomb.transform.position = gunpoint.position;

		Transform target = hitPoints [Random.Range (0, hitPoints.Length)];
		iTween.MoveTo (bomb.gameObject, iTween.Hash ("position", target, "time", flyTime));
		iTween.ScaleTo (bomb.gameObject, iTween.Hash ("scale", target, "time", flyTime));

		audio.Play ();
		playBacklashAnimationOnShip ();

		consumeHitPoint (bomb.mass);
	}

	private void playBacklashAnimationOnShip ()
	{
		iTween.PunchPosition (ship.gameObject, new Vector3 (0f, -1f, 0f), 0.1f);
	}

	#endregion

	#region hit point
	public float maxHitPoint = 100.0f;
	public float curHitPoint = 100.0f;
	public bool isRefeshing = false;

	public void Upgrade (int level)
	{
		float max;

		switch (level) {
		case 2:
			max = 200.0f;
			break;
		case 3:
			max = 300.0f;
			break;

		case 1:
		default:
			max = 100.0f;
			break;
		}

		setMaxHitPoint (max);
	}

	public void Cooldown (float amount)
	{
		if (curHitPoint < maxHitPoint) {
			curHitPoint = Mathf.Min (maxHitPoint, curHitPoint + amount);
			if (isRefeshing && curHitPoint >= maxHitPoint) {
				isRefeshing = false;
			}
		}
		
	}

	private void setMaxHitPoint (float max)
	{
		this.maxHitPoint = max;
		this.curHitPoint = max;
		isRefeshing = false;
	}

	private void consumeHitPoint (float amount)
	{
		curHitPoint = Mathf.Max (0f, curHitPoint - amount);
		if (curHitPoint <= 0) {
			isRefeshing = true;
		}
	}

	#endregion
}
