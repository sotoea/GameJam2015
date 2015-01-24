#pragma strict

var PickUpAnchor : GameObject; // Add an empty gameobject named "PickUpAnchor" to your Camera. I have mine set up at 0 ,0 ,1.25.

var HoldingObject : boolean;
var HoldingGameObject : GameObject;


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
        }
   // if (Input.GetKeyDown ("escape")){
     //   Screen.lockCursor = false; // shows mouse
   // }
}