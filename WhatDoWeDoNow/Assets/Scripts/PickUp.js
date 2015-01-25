#pragma strict

var PickUpAnchor : GameObject; // Add an empty gameobject named "PickUpAnchor" to your Camera. I have mine set up at 0 ,0 ,1.25.

var HoldingObject : boolean;
var HoldingGameObject : GameObject;
var elmine = true;
var dogi : GameObject;


function Start () {
    PickUpAnchor = GameObject.Find("PickUpAnchor"); //Finds the PickUpAnchor GameObject
   // Screen.lockCursor = true; // Locks the cursor at screenwidth / 2,  screenheight / 2 and hides the cursor        
}

function Update () {
	

    if (Input.GetMouseButtonDown(0)/*Input.GetKeyUp(KeyCode.E)*/){  // Checks if we press E
        if (!HoldingObject){ // Only runs if we're not holding an object;
            var ray = Camera.main.ScreenPointToRay (Input.mousePosition); //Shoots a ray from the camera to the mouse (screenwidth / 2,  screenheight / 2)
            var hit : RaycastHit; // hit information
            if (Physics.Raycast (ray, hit, 5)) { // If we hit something within 5m
                if (hit.transform.tag == "CanPickUp"){ // Checks if what we hit has a tag of "canPickUp"
                	
                    Debug.DrawLine(ray.origin, hit.point, Color.white); // illustrates a hit line for demo purposes
                    hit.transform.rigidbody.isKinematic = true; // turns off the pickupable objects rigid body effects, so it doesn't constantly fall or get in the way
                    //hit.collider.enabled = false; // Turns off the collider so we can run around with the object without interfering with our FPS controller
                    hit.transform.position = PickUpAnchor.transform.position; // Moves the object to our pickup anchor
                    hit.transform.parent = PickUpAnchor.transform; // Parents the object with the pickup anchor, so it moves with the player
                    HoldingGameObject = hit.transform.gameObject; // assigns the object to a var so it can be dropped later
                    HoldingObject = true; 
                }
            }
        }
    }else if (Input.GetMouseButtonUp(0)){ //only runs if we're holding an object;
    		
            HoldingGameObject.transform.parent = null; //deparents our holdable object
            //HoldingGameObject.collider.enabled = true; //reenables our colider
            HoldingGameObject.transform.rigidbody.isKinematic = false; // turns on the rigidbody
            HoldingObject = false; //ready to pick up another object
        } if(HoldingObject&&elmine){
			if(HoldingGameObject.name == "giveaDogABone"){
				var temp = Vector3(GameObject.Find("scuba_dawg").transform.position.x,GameObject.Find("scuba_dawg").transform.position.y,GameObject.Find("scuba_dawg").transform.position.z);
				var temp2 = Quaternion(GameObject.Find("scuba_dawg").transform.rotation.x,GameObject.Find("scuba_dawg").transform.rotation.y,GameObject.Find("scuba_dawg").transform.rotation.z,0f);
				Destroy(GameObject.Find("scuba_dawg"));//.GetComponent("dogRotate").SendMessage("changei");
				Instantiate(dogi, temp, temp2);
				elmine = false;
				
				
				//GameObject.Find("scuba_dawg").GetComponent("SmoothLookAt").active = false;
			}
	}
        
   // if (Input.GetKeyDown ("escape")){
     //   Screen.lockCursor = false; // shows mouse
   // }
}