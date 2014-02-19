using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour
{
	public GameObject bombPrefab;
	public Transform gunpoint;
	public float flyTime = 1f;
	public HitSpot[] hitSpots;
	public AudioSource fireSound;

	private GameObject ship;

	// Use this for initialization
	void Start ()
	{ 
		ship = GameObject.Find ("Ship");
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
		GameObject bomb = Instantiate (bombPrefab, gunpoint.position, Quaternion.identity) as GameObject;
		GameObject target = hitSpots [Random.Range (0, hitSpots.Length)].gameObject;

		iTween.MoveTo (bomb, iTween.Hash ("position", target.transform, "time", flyTime));
		iTween.ScaleTo (bomb, new Vector3 (1f, 1f, 1f), flyTime);

		fireSound.Play ();

		playBacklashAnimationOnShip ();
	}

	private void playBacklashAnimationOnShip ()
	{
		iTween.PunchPosition (ship, new Vector3 (0f, -1f, 0f), 0.1f);
	}
}
