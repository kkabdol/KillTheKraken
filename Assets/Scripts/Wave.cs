using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{
	public float wavelength = 1f;
	public float time = 1f;
	public float delay = 0.1f;

	public bool needDarkening = false;

	void Start ()
	{
		iTween.MoveBy (gameObject, 
		               iTween.Hash ("y", wavelength, 
		             				"easeType", "easeOutQuad", 
		             				"loopType", "pingPong", 
		             				"time", time, 
		             				"delay", delay));

		if (needDarkening) {
			Color color = new Color (0.5f, 0.5f, 0.5f, 1f);
			iTween.ColorFrom (gameObject, 
			                iTween.Hash ("color", color, 
			             "easeType", "easeOutQuad", 
			             "loopType", "pingPong", 
			             "time", time, 
			             "delay", delay));
		}
	}
}
