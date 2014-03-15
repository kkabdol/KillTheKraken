using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour
{

	#region bomb
	public Bomb[] bombs;
	public Transform[] bombPos;
	public Transform bombBasePos;
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
			b.transform.parent = transform;
			bombList.Add (b);
		}
		
		resetBombPos (resetPosInstantly);
	}
	
	private void resetBombPos (bool resetPosInstantly)
	{
		for (int i=0; i<bombList.Count; ++i) {
			if (resetPosInstantly) {
				moveBomb (bombList [i], bombPos [i]);
			} else if (i == bombList.Count - 1) {
				moveBomb (bombList [i], bombBasePos);
				tweenMoveBomb (bombList [i], bombPos [i], .5f);
			} else {
				tweenMoveBomb (bombList [i], bombPos [i], .5f);
			}
		}
	}

	private void moveBomb (Bomb bomb, Transform to)
	{
		bomb.transform.position = to.position;
		bomb.transform.localScale = to.localScale;
	}

	private void tweenMoveBomb (Bomb bomb, Transform to, float time)
	{
		iTween.MoveTo (bomb.gameObject, to.position, time);
		iTween.ScaleTo (bomb.gameObject, to.localScale, time);
	}
	
	#endregion

	void Start ()
	{
		addRandomBombToList (bombPos.Length, true);
	}
	
}
