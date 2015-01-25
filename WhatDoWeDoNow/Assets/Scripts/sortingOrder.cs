using UnityEngine;
using System.Collections;
public class sortingOrder : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		// Set the sorting layer of the particle system.
		particleSystem.renderer.sortingLayerName = "background";
		particleSystem.renderer.sortingOrder = 0;
	}		
}