using UnityEngine;
using System.Collections;

public class dogRotate : MonoBehaviour {
	
	public float a = 0f;
	public float b = 0f;
	public float r = 10f;
	public float theta = 0f;
	public float deltaT = 0.05f;

	int i =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(i==0){
		theta = theta + deltaT*Mathf.Deg2Rad;
		Vector3 temp = transform.position;
		temp.x = a + r*Mathf.Cos(theta);
		temp.z = b + r*Mathf.Sin(theta);
		transform.position = temp;
		
		transform.Rotate(Vector3.up*Time.deltaTime);
		
		}else if (i ==10){
			theta = theta + deltaT*Mathf.Deg2Rad;
			Vector3 temp = transform.position;
			temp.x = a + r*Mathf.Cos(theta);
			temp.z = b + r*Mathf.Sin(theta);
			transform.position = temp;
			
			transform.Rotate(Vector3.up*Time.deltaTime);
		}
		
	}

	void changei(){
		i = 10;

	}
}