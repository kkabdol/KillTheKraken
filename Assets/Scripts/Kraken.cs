using UnityEngine;
using System.Collections;

public class Kraken : MonoBehaviour
{

	void Start ()
	{
		saveDefaultColor ();
	}

	void Update ()
	{
		updateStiffening ();
	}

	#region hit

	public void Hit (float damage)
	{
		StartStiffening ();
		ScatterCoins (damage);
	}

	#endregion

	#region Color
	public SpriteRenderer[] renderers;
	private Color[] defaultRenderColors;
	
	private void saveDefaultColor ()
	{
		this.defaultRenderColors = new Color[this.renderers.Length];
		for (int i=0; i<this.renderers.Length; ++i) {
			this.defaultRenderColors [i] = this.renderers [i].material.color;
		}
	}

	private void changeColor (Color color)
	{
		for (int i=0; i<this.renderers.Length; ++i) {
			this.renderers [i].material.color = color;
		}
	}

	private void restoreColor ()
	{
		for (int i=0; i<renderers.Length; ++i) {
			this.renderers [i].material.color = this.defaultRenderColors [i];
		}
	}
	#endregion

	#region Stiffening
	public float stiffenDuration = 0.1f;
	private float stiffenElapsedTime = 0;
	private bool isStiffened = false;

	private void StartStiffening ()
	{
		playKnockbackAnimation ();

		stiffenElapsedTime = 0f;

		if (!isStiffened) {
			changeColor (Color.yellow);
			isStiffened = true;
		}
	}

	private void playKnockbackAnimation ()
	{
		iTween.PunchPosition (this.gameObject, new Vector3 (0f, 0.5f, 0f), 0.1f);
	}

	private void updateStiffening ()
	{
		if (isStiffened) {
			stiffenElapsedTime += Time.deltaTime;
			if (stiffenElapsedTime > stiffenDuration) {
				isStiffened = false;
				stiffenElapsedTime = 0f;
				restoreColor ();
			}
		}

	}
	#endregion

	#region Coin
	public Coin[] coins;
	public Transform coinFrom;
	public Transform[] coinTo;
	public AudioSource coinSound;
	public float minCoinFlyTime = 2f;
	public float maxCoinFlyTime = 4f;

	private float[] minMassForCoin = {
		0f,
		20f,
		40f,
		60f,
		80f,
	};

	private void ScatterCoins (float damage)
	{
		int index = GetCoinIndexByMass (damage);
		Debug.Log ("coin type : " + index + " by damage : " + damage);

		Vector3 to = new Vector3 (Random.Range (coinTo [0].position.x, coinTo [1].position.x), 
		                         Random.Range (coinTo [0].position.y, coinTo [1].position.y),
		                         Random.Range (coinTo [0].position.z, coinTo [1].position.z));
		float flyTime = Random.Range (minCoinFlyTime, maxCoinFlyTime);

		Coin coin = Instantiate (coins [index], coinFrom.position, Quaternion.identity) as Coin;
		coin.GetComponent<Wave> ().needDarkening = true;

		iTween.MoveTo (coin.gameObject, iTween.Hash ("position", to, "time", flyTime));
		iTween.ScaleTo (coin.gameObject, new Vector3 (1f, 1f, 1f), flyTime);
		coinSound.Play ();
	}

	private int GetCoinIndexByMass (float damage)
	{
		int index = 0;
		for (int i=minMassForCoin.Length-1; i>=0; --i) {
			if (minMassForCoin [i] <= damage) {
				index = i;
				break;
			}
		}

		return index;
	}

	#endregion
}
