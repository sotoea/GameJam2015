using UnityEngine;
using System.Collections;

public class Controller2 : MonoBehaviour {

	private bool highAllTheTime = false;
	public Rigidbody bullet;
	public GameObject goal;

	public GameObject gun;

	
	// Use this for initialization
	void Start () {
	
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update(){
		if(transform.position.x<3.8&&transform.position.x>3.4&&transform.position.z<13.8&&transform.position.z>13.4){
			highAllTheTime = true;
		}
		if(highAllTheTime){
			transform.Translate(Vector3.up*Time.deltaTime*100);
			if(transform.position.y>100){
				Application.LoadLevel("lvl3_001");
			}
		}
		//Screen.lockCursor = true;
		if(transform.position.y <-25){
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if(Input.GetKey("escape"))
			Application.Quit();
		
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Rigidbody clone;
			clone = Instantiate(bullet, transform.position+(new Vector3(0,0,0.5f)), transform.rotation) as Rigidbody;
			clone.velocity = transform.TransformDirection(Vector3.forward * 10);
			GameObject.FindWithTag("braingun").animation.Play("shoot");
			GameObject.Find("brain_gun").animation.Play("shoot");
			//transform.GetChild(1).animation.Play("shoot");
			gun.animation.Play("shoot");
			
			/*Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				
				// the object identified by hit.transform was clicked
				// do whatever you want
				if(hit.transform.gameObject.name == "Button"){
					hit.transform.gameObject.animation.Play("PushButton");

				}else if(hit.transform.gameObject.name == "FinalButton"){
					if(transform.position.y > 11.5){
						hit.transform.gameObject.animation.Play("FinalPush");
						highAllTheTime = true;
						
					}
				}
			}*/
		}
	}
}