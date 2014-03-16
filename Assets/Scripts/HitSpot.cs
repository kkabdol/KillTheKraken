using UnityEngine;
using System.Collections;

public class HitSpot : MonoBehaviour
{
	private Kraken kraken;

	void Awake ()
	{
		kraken = GameObject.FindGameObjectWithTag (Tags.kraken).GetComponent<Kraken> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Equals (Tags.blackBomb)) {
			float power = other.GetComponent<Bomb> ().power;
			kraken.Hit (power);

			Destroy (other.gameObject);
		}
	}

}
