using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{ 
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			Vector3 point = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			FaceTo (point);

			if (Input.GetMouseButtonUp (0)) {
				Fire ();
			}
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

	}
}
