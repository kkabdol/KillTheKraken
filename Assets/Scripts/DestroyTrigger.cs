using UnityEngine;
using System.Collections;

public class DestroyTrigger : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("DestroyTrigger Destroyed an object");
		Destroy (other.gameObject);
	}
}