using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Vector3 elMio = Vector3.back;

	public bool move = true;
	void changeMove(){
		move = false;
	}
	// Use this for initialization
	void Start () {
		//transform.RotateAround(transform.position, Vector3.up, 180);
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.animation.IsPlaying("Death")){
			move = false;
		}
		if(move){
			transform.Translate(elMio*Time.deltaTime*5);
			if(transform.position.x<-27){
				//transform.position = new Vector3(-9.5f,transform.position.y,transform.position.z);
			//	elMio = Vector3.back;
			//	transform.RotateAround(transform.position, Vector3.up, 180);
				transform.position = new Vector3(26f,transform.position.y,transform.position.z);
			}else if(transform.position.x>27){
		
				//elMio = Vector3.forward;
				//transform.RotateAround(transform.position, Vector3.up, 180);
				transform.position = new Vector3(26f,transform.position.y,transform.position.z);
		}
		}
	}
}
