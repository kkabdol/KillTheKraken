using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour
{

	#region bomb
	public Bomb[] bombs;
	public Transform[] bombPos;
	private List<Bomb> bombList = new List<Bomb> ();

	public Bomb PopBomb ()
	{
		Bomb b = bombList [0];
		bombList.Remove (b);
		addRandomBombToList (1, false);
		
		return b;
	}
	
	private void addRandomBombToList (int count, bool resetPosInstantly)
	{
		for (int i=0; i<count; ++i) {
			Bomb b = Instantiate (bombs [Random.Range (0, bombs.Length)]) as Bomb;
			bombList.Add (b);
		}
		
		resetBombPos (resetPosInstantly);
	}
	
	private void resetBombPos (bool resetPosInstantly)
	{
		for (int i=0; i<bombList.Count; ++i) {
			if (resetPosInstantly || i == bombList.Count - 1) {
				bombList [i].transform.position = bombPos [i].position;
				bombList [i].transform.localScale = bombPos [i].localScale;
			} else {
				iTween.MoveTo (bombList [i].gameObject, bombPos [i].position, 0.5f);
				iTween.ScaleTo (bombList [i].gameObject, bombPos [i].localScale, 0.5f);
			}
		}
	}
	
	#endregion

	void Start ()
	{
		addRandomBombToList (bombPos.Length, true);
	}
	
}
