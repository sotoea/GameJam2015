using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float a = 0f;
	public float b = 0f;
	public float r = 10f;
	public float theta = 0f;
	public float deltaT = 0.05f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		theta = theta + deltaT*Mathf.Deg2Rad;
		Vector3 temp = transform.position;
		temp.x = a + r*Mathf.Cos(theta);
		temp.z = b + r*Mathf.Sin(theta);
		transform.position = temp;

		transform.Rotate(Vector3.up*Time.deltaTime);

	}
}
