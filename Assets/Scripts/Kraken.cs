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

	public void StartStiffening ()
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
	public GameObject coinPrefab;
	public Transform coinFrom;
	public Transform[] coinTo;
	public AudioSource coinSound;
	public float minCoinFlyTime = 2f;
	public float maxCoinFlyTime = 4f;

	public void ScatterCoins (int count)
	{
		for (int i=0; i<count; ++i) {
			Vector3 to = new Vector3 (Random.Range (coinTo [0].position.x, coinTo [1].position.x), 
		                         Random.Range (coinTo [0].position.y, coinTo [1].position.y),
		                         Random.Range (coinTo [0].position.z, coinTo [1].position.z));
			float flyTime = Random.Range (minCoinFlyTime, maxCoinFlyTime);

			GameObject coin = Instantiate (coinPrefab, coinFrom.position, Quaternion.identity) as GameObject;
			coin.GetComponent<Wave> ().needDarkening = true;

			iTween.MoveTo (coin, iTween.Hash ("position", to, "time", flyTime));
			iTween.ScaleTo (coin, new Vector3 (1f, 1f, 1f), flyTime);
			coinSound.Play ();
		}



	}

	#endregion
}
