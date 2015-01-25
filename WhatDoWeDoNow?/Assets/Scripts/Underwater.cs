using UnityEngine;
using System.Collections;

public class Underwater : MonoBehaviour {
	public float incforce = 0f;
	const float maxForce = 5f;
	int decel = 0;

	public float incforce2 = 0f;
	int decel2 = 0;

	void Update() {
		print (transform.rigidbody.velocity);
		//transform.Translate(0,0.01f*Mathf.Sin(Time.realtimeSinceStartup*Mathf.PI),0);

		transform.rigidbody.AddForce(Camera.main.transform.forward*incforce);
		transform.rigidbody.AddForce(Vector3.right*incforce2);



		if(Camera.main.transform.rigidbody.velocity.z>=10f) Camera.main.transform.rigidbody.velocity = new Vector3(Camera.main.transform.rigidbody.velocity.x,Camera.main.transform.rigidbody.velocity.y,10);
		if(Camera.main.transform.rigidbody.velocity.z<=-10f) Camera.main.transform.rigidbody.velocity = new Vector3(Camera.main.transform.rigidbody.velocity.x,Camera.main.transform.rigidbody.velocity.y,-10);
		if(Camera.main.transform.rigidbody.velocity.x>=10f) Camera.main.transform.rigidbody.velocity = new Vector3(10,Camera.main.transform.rigidbody.velocity.y,Camera.main.transform.rigidbody.velocity.z);
		if(Camera.main.transform.rigidbody.velocity.x<=-10f) Camera.main.transform.rigidbody.velocity = new Vector3(-10,Camera.main.transform.rigidbody.velocity.y,Camera.main.transform.rigidbody.velocity.z);
		if(Camera.main.transform.rigidbody.velocity.y>=10f) Camera.main.transform.rigidbody.velocity = new Vector3(Camera.main.transform.rigidbody.velocity.x,10,Camera.main.transform.rigidbody.velocity.z);
		if(Camera.main.transform.rigidbody.velocity.y<=-10f) Camera.main.transform.rigidbody.velocity = new Vector3(Camera.main.transform.rigidbody.velocity.x,-10, Camera.main.transform.rigidbody.velocity.z);

		if (decel == 0 && Input.GetKey("w") && incforce<maxForce){
			incforce += 0.5f;

		}else if(Input.GetKeyUp("w")){
			decel = -1;
			incforce = -incforce;

		}
		if (decel == 0 &&  Input.GetKey("s")&& incforce>-maxForce){
			incforce -= 0.5f;

		}else if(Input.GetKeyUp("s")){
			decel = 1;
			incforce = -1*incforce;
		}

		if(decel == -1){
			Camera.main.transform.rigidbody.AddForce(Vector3.forward*incforce);
			incforce+=0.1f;
			if(incforce>=0||Camera.main.transform.rigidbody.velocity.z<=0){
				incforce = 0;
				decel = 0;
				Camera.main.transform.rigidbody.velocity = new Vector3(Camera.main.transform.rigidbody.velocity.x,Camera.main.transform.rigidbody.velocity.y,0);
			}
		}

		if(decel == 1){
			Camera.main.transform.rigidbody.AddForce(Vector3.forward*incforce);
			incforce-=0.1f;
			if(incforce<=0||transform.rigidbody.velocity.z>=0){
				incforce = 0;
				decel = 0;
				Camera.main.transform.rigidbody.velocity = new Vector3(Camera.main.transform.rigidbody.velocity.x,Camera.main.transform.rigidbody.velocity.y,0);
			}
		}

		if (decel2 == 0 && Input.GetKey("d") && incforce2<maxForce){
			incforce2 += 0.5f;
			

		}else if(Input.GetKeyUp("d")){
			decel2 = -1;
			incforce2 = -incforce2;
		}
		if (decel2 == 0 &&  Input.GetKey("a")&& incforce2>-maxForce){
			incforce2 -= 0.5f;

		}else if(Input.GetKeyUp("a")){
			decel2 = 1;
			incforce2 = -incforce2;
		}
		
		if(decel2 == -1){
			Camera.main.transform.rigidbody.AddForce(Vector3.right*incforce2);
			incforce2+=0.1f;
			if(incforce2>=0||transform.rigidbody.velocity.x<=0){
				incforce2 = 0;
				decel2 = 0;
				Camera.main.transform.rigidbody.velocity = new Vector3(0,Camera.main.transform.rigidbody.velocity.y,Camera.main.transform.rigidbody.velocity.z);
			}
		}
		
		if(decel2 == 1){
			Camera.main.transform.rigidbody.AddForce(Vector3.right*incforce2);
			incforce2-=0.1f;
			if(incforce2<=0||transform.rigidbody.velocity.x>=0){
				incforce2 = 0;
				decel2 = 0;
				Camera.main.transform.rigidbody.velocity = new Vector3(0,Camera.main.transform.rigidbody.velocity.y,Camera.main.transform.rigidbody.velocity.z);
			}
		}
		
	}
}