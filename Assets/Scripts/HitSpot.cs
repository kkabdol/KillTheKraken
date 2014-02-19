using UnityEngine;
using System.Collections;

public class HitSpot : MonoBehaviour
{
	private Kraken kraken;

	void Start ()
	{
		kraken = GameObject.Find ("Kraken").GetComponent<Kraken> () as Kraken;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("DestroyTrigger Destroyed an object");
		Destroy (other.gameObject);

		kraken.StartStiffening ();
	}

}
