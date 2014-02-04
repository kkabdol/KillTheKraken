using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour
{
	public float wavelength = 1f;
	public float time = 1f;
	public float delay = 0.1f;

	void Start ()
	{
		iTween.MoveBy (gameObject, 
		               iTween.Hash ("y", wavelength, 
		             				"easeType", "easeOutQuad", 
		             				"loopType", "pingPong", 
		             				"time", time, 
		             				"delay", delay));
	}
}
