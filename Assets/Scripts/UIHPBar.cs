using UnityEngine;
using System.Collections;

public class UIHPBar : MonoBehaviour
{
	private Cannon cannon;
	private UIProgressBar bar;
	private UISprite sprite;
	private bool isRefreshing = false;

	void Awake ()
	{
		cannon = GameObject.FindGameObjectWithTag (Tags.cannon).GetComponent<Cannon> ();
		bar = GetComponent<UIProgressBar> ();
		sprite = GetComponent<UISprite> ();
	}

	// Update is called once per frame
	void Update ()
	{
		bar.value = cannon.curHitPoint / cannon.maxHitPoint;

		if (cannon.isRefeshing && !isRefreshing) {
			isRefreshing = true;
			sprite.color = Color.green;
		} else if (!cannon.isRefeshing && isRefreshing) {
			isRefreshing = false;
			sprite.color = Color.red;
		}
	}
}
