using UnityEngine;
using System.Collections;
public class sortingOrder : MonoBehaviour {
	GameObject gol = GameObject.Find("Goal");
	// Use this for initialization
	void Start () 
	{

	}	

	void Update(){
		transform.Translate(Vector3.forward*0.1f);

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.name == "Goal"){
			Application.LoadLevel("Scene1");
		}
	}
}