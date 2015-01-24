using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if(transform.position.y<-20)
			Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider collision) {
		rigidbody.velocity = transform.TransformDirection(-rigidbody.velocity.x*0.5f,-rigidbody.velocity.y*0.2f,-rigidbody.velocity.z*0.5f);
		collision.animation.Play("Death");
		
	}
}
