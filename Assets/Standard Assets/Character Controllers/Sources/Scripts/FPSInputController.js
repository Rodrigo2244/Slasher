private var motor : CharacterMotor;
public  var PlayerId : int;
public var isDown : boolean = true;
public var isPaused : boolean = false;
// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
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
}

function OnGUI(){
	if(Input.GetAxis("Pause") == 1 && isDown){
		isDown = false;
		isPaused = true;
		Time.timeScale = 0;
		if(isPaused){
			if(GUI.Button(new Rect (Screen.width/2, Screen.height/2, 84,60), "Return to Menu")){
				Application.LoadLevel("Menus");
			}
		}
	}
	if(Input.GetAxis("Pause") == 0){
		isDown = true;
	}
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Controller")
