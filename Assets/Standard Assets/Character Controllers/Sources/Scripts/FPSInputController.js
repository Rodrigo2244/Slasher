private var motor : CharacterMotor;
public  var PlayerId : int;
public var isDown : boolean = true;
public var isPaused : boolean = false;
public var controller : GameObject;
public var win : boolean = false;
public var buttons : GUIStyle;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
	controller = gameObject.Find("Game Controller");

}

// Update is called once per frame
function Update () {
	// Get the input vector from keyboard or analog stick
	var directionVector = new Vector3(Input.GetAxis("Horizontal"+ PlayerId), 0, Input.GetAxis("Vertical" + PlayerId));
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector;
	//motor.inputJump = Input.GetButton("Jump");
	
	if(Input.GetButtonDown("Pause")){
		if(isPaused){
			Screen.showCursor = false;
			isPaused = false;
			Time.timeScale = 1;
		}
		else{
			isPaused = true;
			Screen.showCursor = true;
			Time.timeScale = 0;
		}
		controller.GetComponent("GameController").isPaused = isPaused;
	}
}

function OnGUI(){
	if(isPaused){
		if(GUI.Button(new Rect (1061/2-150, 597/2-30, 300,60), "Return to Menu", buttons)){
			Destroy(controller);
			Time.timeScale = 1;
			Application.LoadLevel("Menus");
		}
	}
}
function OnTriggerEnter(other : Collider)
{
	if(other.CompareTag("Win"))
	{
		win = true;
		controller.GetComponent("GameController").HasWon(PlayerId);
		transform.GetChild(0).gameObject.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(false);
		transform.GetChild(2).gameObject.SetActive(false);
	}
}
// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
