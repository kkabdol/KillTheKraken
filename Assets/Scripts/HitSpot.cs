using UnityEngine;
using System.Collections;

public class HitSpot : MonoBehaviour
{
	public Kraken kraken;
	
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("DestroyTrigger Destroyed an object");
		Destroy (other.gameObject);

		kraken.StartStiffening ();
		kraken.ScatterCoins (1);
	}

}
