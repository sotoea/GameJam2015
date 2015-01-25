using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {
	public GameObject fishPlane;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y<-20)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.name == "fish_02"){
		rigidbody.velocity = transform.TransformDirection(-rigidbody.velocity.x*0.5f,-rigidbody.velocity.y*0.2f,-rigidbody.velocity.z*0.5f);
		collision.animation.Play("Death");
		Instantiate(fishPlane,collision.transform.position-(new Vector3(1.85f,-0.5f,0f)), Quaternion.Euler(0,0,0));
			fishPlane.transform.parent = collision.transform;
			collision.SendMessage("changeMove");
		}
		
	}
}
