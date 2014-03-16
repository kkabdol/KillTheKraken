using UnityEngine;
using System.Collections;

public class UIFireButton : MonoBehaviour
{
	private Cannon cannon;
	private UIButton button;

	void Awake ()
	{
		cannon = GameObject.FindGameObjectWithTag (Tags.cannon).GetComponent<Cannon> ();
		button = GetComponent<UIButton> ();
	}
	
	void Update ()
	{
		if (cannon.isRefeshing && button.enabled) {
			button.enabled = false;
			foreach (UISprite sprite in button.GetComponentsInChildren<UISprite>()) {
				sprite.color = Color.grey;
			}
		} else if (!cannon.isRefeshing && !button.enabled) {
			button.enabled = true;
			foreach (UISprite sprite in button.GetComponentsInChildren<UISprite>()) {
				sprite.color = Color.white;
			}
		}
	}
}
