using UnityEngine;
using System.Collections;

public class Kraken : MonoBehaviour
{
	public SpriteRenderer[] renderers;
	private Color[] defaultRenderColors;

	public float stiffenDuration = 0.1f;
	public float stiffenElapsedTime = 0;
	private bool isStiffened = false;

	void Start ()
	{
		saveDefaultColor ();
	}

	void Update ()
	{
		updateStiffening ();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log ("DestroyTrigger Destroyed an object");
		Destroy (other.gameObject);

		startStiffening ();
	}

	private void saveDefaultColor ()
	{
		this.defaultRenderColors = new Color[this.renderers.Length];
		for (int i=0; i<this.renderers.Length; ++i) {
			this.defaultRenderColors [i] = this.renderers [i].material.color;
		}
	}

	private void changeColor (Color color)
	{
		for (int i=0; i<this.renderers.Length; ++i) {
			this.renderers [i].material.color = color;
		}
	}

	private void restoreColor ()
	{
		for (int i=0; i<renderers.Length; ++i) {
			this.renderers [i].material.color = this.defaultRenderColors [i];
		}
	}

	private void startStiffening ()
	{
		stiffenElapsedTime = 0f;

		if (!isStiffened) {
			changeColor (Color.yellow);
			isStiffened = true;
		}
	}

	private void updateStiffening ()
	{
		if (isStiffened) {
			stiffenElapsedTime += Time.deltaTime;
			if (stiffenElapsedTime > stiffenDuration) {
				isStiffened = false;
				stiffenElapsedTime = 0f;
				restoreColor ();
			}
		}

	}
}
