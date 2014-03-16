using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour
{
	private Ship ship;
	private Cannon cannon;

	void Awake ()
	{
		ship = GameObject.FindGameObjectWithTag (Tags.ship).GetComponent<Ship> ();
		cannon = GameObject.FindGameObjectWithTag (Tags.cannon).GetComponent<Cannon> ();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow)) {
			ship.trashRedBomb ();
		} else if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow)) {
			cannon.Fire ();
		}	
	}
}
