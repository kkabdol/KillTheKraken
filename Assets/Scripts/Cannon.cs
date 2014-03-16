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
	public bool isRefeshing = false;
	public float maxHitPoint = 100.0f;
	public float curHitPoint = 100.0f;

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

	#region upgrade
	private float[] maxHitPointList = {
		100f,
		150f,
		200f,
		250f,
		300f,
		350f,
		400f,
		450f,
	};
	
	public void LevelUp (int level)
	{
		if (level >= 2 || level < maxHitPointList.Length) {
			setMaxHitPoint (maxHitPointList [level - 2]);
		}
	}
	#endregion
}
