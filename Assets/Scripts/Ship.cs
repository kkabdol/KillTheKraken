using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour
{
	
	void Start ()
	{
		addRandomBombToList (bombPos.Length, true);
	}

	#region bomb
	public Bomb[] bombs;
	public int[] bombChance;
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
			int index = 0;

			int per = Random.Range (0, 100);
			for (int j=0; j<bombChance.Length; ++j) {
				if (per < bombChance [j]) {
					index = j;
					break;
				} else {
					per -= bombChance [j];
				}
			}


			Bomb b = Instantiate (bombs [index]) as Bomb;
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

	#region trash current red bomb
	public void trashRedBomb ()
	{
		if (bombList [0].isRedBomb) {
			Bomb bomb = PopBomb ();
			Destroy (bomb.gameObject);
		}
	}
	#endregion

	#region upgrade
	private int[,] bombChanceList = new int[,] {
		{80, 10, 0, 0, 0,  0, 0, 0, 0, 10},
		{70, 15, 5, 0, 0,  0, 0, 0, 0, 10},
		{60, 20, 5, 5, 0,  0, 0, 0, 0, 10},
		{50, 25, 5, 5, 5,  0, 0, 0, 0, 10},

		{40, 30, 5, 5, 5,  5, 0, 0, 0, 10},
		{30, 35, 5, 5, 5,  5, 5, 0, 0, 10},
		{20, 40, 5, 5, 5,  5, 5, 5, 0, 10},
		{10, 45, 5, 5, 5,  5, 5, 5, 5, 10},
		{5, 50, 5, 5, 5,  5, 5, 5, 5, 10},
	};
	
	public void LevelUp (int level)
	{
		if (level >= 2 || level < bombChanceList.Length) {
//			Debug.Log ("bombChanceList.GetLength(" + (level - 2) + ") : " + ));
			for (int i=0; i<10; ++i) {
				bombChance [i] = bombChanceList [level - 2, i];
			}
		}
	}
	#endregion
}
