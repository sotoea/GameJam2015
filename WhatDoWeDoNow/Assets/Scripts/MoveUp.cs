using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("space")){
						transform.position += Vector3.up * 0.4f;
				}
	}
}
