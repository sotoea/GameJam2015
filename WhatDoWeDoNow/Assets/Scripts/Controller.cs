using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public GameObject cub;
	private bool highAllTheTime = false;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update(){
		if(highAllTheTime){
			transform.Translate(Vector3.up*Time.deltaTime*100);
			if(transform.position.y>150){
				Application.LoadLevel("lvl2_004_withGameplay");
			}
		}
		//Screen.lockCursor = true;
		if(transform.position.y <-25){
			Application.LoadLevel(Application.loadedLevel);
		}

		if(Input.GetKey("escape"))
			Application.Quit();

		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){

				// the object identified by hit.transform was clicked
				// do whatever you want
				if(hit.transform.gameObject.name == "Button"){
				hit.transform.gameObject.animation.Play("PushButton");
				Vector3 temp = new Vector3(Random.Range(-5f,5f), 10f, Random.Range(-5f,5f));
				Quaternion temp2 = Quaternion.Euler(Random.Range(0f,90f),Random.Range(0f,90f),Random.Range(0f,90f));
				Instantiate(cub, temp, temp2); //as Transform;
				}else if(hit.transform.gameObject.name == "FinalButton"){
					if(transform.position.y > 11.5){
						hit.transform.gameObject.animation.Play("FinalPush");
						highAllTheTime = true;

					}
				}
			}
		}
	}
}
