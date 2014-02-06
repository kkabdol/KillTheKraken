using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public GameObject bombPrefab;
	public Transform gunpoint;
	public float bombPower = 300f;
	public float bombTorque = 50f;

	// Use this for initialization
	void Start ()
	{ 

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isTouched ()) {
			Fire ();
		}
	}

	bool isTouched ()
	{
		if (Input.GetMouseButtonDown (0)) {
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);		
//			RaycastHit hit;
//			return this.collider.Raycast (ray, out hit, 100.0f);

			Vector3 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			return this.collider2D.OverlapPoint (new Vector2 (point.x, point.y));
		} else {
			return false;
		}
	}
	
	public void FaceTo (Vector3 target)
	{
		Vector3 relativePos = target - transform.position;
		Quaternion rotation = Quaternion.LookRotation (relativePos, Vector3.back);
		transform.rotation = rotation;
	}

	public void Fire ()
	{
		Debug.Log ("Fire");
		GameObject bomb = Instantiate (bombPrefab, gunpoint.position, Quaternion.identity) as GameObject;
		bomb.rigidbody2D.AddForce (new Vector2 (0f, bombPower));
		bomb.rigidbody2D.AddTorque (bombTorque);
	}
}
