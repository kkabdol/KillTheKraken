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
		if (canGetCoin) {
			canGetCoin = false;

			Destroy (other.gameObject);
			coinSound.Play ();
		}
	}


	#region Movement

	private void move (Direction dir)
	{
		Debug.Log ("move " + dir);

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
	public AudioSource coinSound;

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
}
