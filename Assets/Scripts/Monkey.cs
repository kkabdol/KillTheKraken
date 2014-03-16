using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour
{

	enum Direction
	{
		Left,
		Right
	}

	public Transform left;
	public Transform right;
	public float moveSpeed = 0.1f;
	public Status status;


	// Use this for initialization
	void Start ()
	{
		initCoinGet ();
		move (Direction.Left);
	}

	void Update ()
	{
		updateCoin ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (canGetCoin && other.tag.Equals (Tags.coin)) {
			canGetCoin = false;

			Coin coin = other.GetComponent<Coin> ();
			status.money += coin.price;

			audio.Play ();

			Destroy (other.gameObject);
		}
	}


	#region Movement

	private void move (Direction dir)
	{
		Vector3 to;
		Direction next;
		Vector3 oldScale = this.gameObject.transform.localScale;

		switch (dir) {
		case Direction.Right:
			to = right.position;
			next = Direction.Left;
			this.gameObject.transform.localScale = new Vector3 (-Mathf.Abs (oldScale.x), oldScale.y, oldScale.z);
			break;
		default:
		case Direction.Left:
			to = left.position;
			next = Direction.Right;
			this.gameObject.transform.localScale = new Vector3 (Mathf.Abs (oldScale.x), oldScale.y, oldScale.z);
			break;
		}
		
		iTween.MoveTo (this.gameObject, iTween.Hash ("position", to, "speed", moveSpeed, "easetype", iTween.EaseType.linear, "oncomplete", "move", "oncompletetarget", this.gameObject, "oncompleteparams", next));
	}
	#endregion

	#region Get Coin
	public float coinGetTime = 1f;

	private float coinGetElapsed = 0f;
	private bool canGetCoin = true;

	private void initCoinGet ()
	{
		canGetCoin = true;
		coinGetElapsed = 0f;
	}

	private void updateCoin ()
	{
		if (canGetCoin == false) {
			coinGetElapsed += Time.deltaTime;
			if (coinGetElapsed > coinGetTime) {
				canGetCoin = true;
				coinGetElapsed = 0f;
			}
		}
	}
	#endregion

	#region upgrade
	private float[] moveSpeedList = {
		1.0f,
		1.5f,
		2.0f,
		2.5f,
		3.0f,
		3.5f,
		4.0f,
		4.5f,
	};
	private float[] coinGetTimeList = {
		1f,
		.9f,
		.8f,
		.7f,
		.6f,
		.5f,
		.4f,
		.3f,
	};
	
	public void LevelUp (int level)
	{
		if (level >= 2 || level < moveSpeedList.Length) {
			moveSpeed = moveSpeedList [level - 2];
		}

		if (level >= 2 || level < coinGetTimeList.Length) {
			coinGetTime = coinGetTimeList [level - 2];
		}
	}
	#endregion
}
