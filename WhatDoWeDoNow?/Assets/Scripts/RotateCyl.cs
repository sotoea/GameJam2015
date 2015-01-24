using UnityEngine;
using System.Collections;

public class RotateCyl : MonoBehaviour {
	public int multiplier;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up*Time.deltaTime*multiplier);
	}
}
