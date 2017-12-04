using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	//movement constants
	public int jumpSpeed=24;
	public float horizontalSpeed=10;
	public float gravity = 85;
	public int right = 0;
	public int left = 0;
	public bool jump=false;
	private Vector3 moveDirection = Vector3.zero;
	public bool D_jump=true;
	private bool double_jump=true;
	//Thrust variables
	public float vertical_thrust_jump_speed = 24*2.5f;
	public float direction;
	private float thrust_h;
	private float thrust_v;
	public float Thust_h_vert_speed=24f;
	//Checkpoint
	private bool hit_checkpoint=false;
	private Vector3 checkpoint_pos;
	//Treadmill
	private float treadmill_dir=0;
	public int treadmill_speed=8; //must be < 8
	//platform
	public GameObject weight_act_platform;
	public float platform_speed=0f; //momentum
	private int activate_momentum=0;
	//GUI elements
	public GUITexture left_button;
	public GUITexture right_button;
	public GUITexture jump_button;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//bool jump = false;
			CharacterController controller = GetComponent<CharacterController>();
		//####Touch Input horizontal Direction####
		//make foreeach inside if(touches>0)
		/*if(Input.touchCount > 0)
		{
		foreach(Touch touch in Input.touches)
		{
			if(touch.phase==TouchPhase.Began && left_button.HitTest (touch.position))
			{
				left = 1;
			}
			else 
			{
				if(touch.phase==TouchPhase.Ended && left_button.HitTest(touch.position))
				{
				left = 0;
				}
			}
			if(touch.phase==TouchPhase.Began && right_button.HitTest (touch.position))
			{
				right = 1;
			}
			
			else
			{
				if(touch.phase==TouchPhase.Ended && right_button.HitTest(touch.position))
				{
				right = 0;
				}
			}
			if(touch.phase == TouchPhase.Began && jump_button.HitTest(touch.position))
			{
				jump = true;
			}
		}
			
		}*/
		// ###END###
		//####Calculate horizontal Direction#####
#if UNITY_EDITOR || UNITY_STANDALONE
			if(Input.GetKey(KeyCode.RightArrow))
			{
				right = 1;
			}
			else 
			{
				right =0;
			}
			
			if(Input.GetKey(KeyCode.LeftArrow))
			{
				left = 1;
			}
			else
			{
				left = 0;
			}
			direction  = right-left; //calculate player direction
			// ###END###
#endif
		
			// player on the ground Movement
			if(controller.isGrounded)
			{
				moveDirection = new Vector3(direction,0,0) /*+ new Vector3(horizontalSpeed*5,0,0)*thrust_h*/;
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection *= horizontalSpeed;
				moveDirection.x +=20*thrust_h;
				moveDirection.x +=treadmill_dir * treadmill_speed;
			
				if(thrust_h !=0)
				{
					thrust_h=0;
					
			 	}
				if(Input.GetKey(KeyCode.UpArrow) || jump)
				{
					moveDirection.y=jumpSpeed;
					audio.Play();
				}
				if(thrust_v == 1)
				{
					moveDirection.y=vertical_thrust_jump_speed;
				}
			double_jump=true;
			}
		
			// player mid air Movement
			if(!controller.isGrounded)
			{
				moveDirection.x = direction;
				moveDirection.x *=horizontalSpeed;
				moveDirection.x += 20 * thrust_h;
				moveDirection.x += treadmill_dir * treadmill_speed;
				moveDirection.x += platform_speed * activate_momentum; //add momentum when out of platform
			if(Input.GetKeyDown(KeyCode.UpArrow) || jump)
				{
					if(D_jump){
					if(double_jump){
						moveDirection.y=jumpSpeed;
						double_jump=false;
						audio.Play();
					}
				}
				}
			}
		
			// if on jump collides with something above -> go down
			if(controller.collisionFlags == CollisionFlags.Above)
			{ 
				Debug.Log("Lx");
				moveDirection.y-=1;
			}
			
			moveDirection.y -= gravity * Time.deltaTime; //Set Gravity
			controller.Move(moveDirection * Time.deltaTime); //move the player
		jump=false;
			
}
	void OnTriggerStay (Collider other){	
		Debug.Log(direction);
		if(other.tag == "Platform")
		{
		transform.parent = other.transform.parent;
		//Weight Activated platform code 
		if(Application.loadedLevelName== "level_9" ||Application.loadedLevelName== "level_16"){
			other.transform.parent.GetComponent<h_platform_weight_activated>().can_move=true;
		}
			Debug.Log("OnPlatform");
		}
		if(other.tag == "elevator"){
			other.transform.parent.GetComponent<elevator>().can_move=true;
			}
		if(other.tag == "lvl19_elevator"){
			transform.parent = other.transform.parent;
			other.transform.parent.GetComponent<vertical_platform_level19>().can_move=true;
		}
		
		if(other.tag=="treadmill")
		{
			treadmill_dir = other.GetComponent<Treadmill>().dir;
		}
		
	}
	void OnTriggerEnter(Collider other){
		if(other.tag =="lvl_end"){
			
			var a = new Save_data();
			a.Save();
		}
		if(other.tag=="Platform"){
		}
		if(other.tag=="checkpoint"){
			hit_checkpoint=true;
			checkpoint_pos= transform.position;
		}
		if(other.tag=="Laser")
		{
			//die
			if(Application.loadedLevelName=="Climb"){
				if(PlayerPrefs.GetInt("High_climb")<GameObject.Find("score").GetComponent<score>().Max_hight){
					PlayerPrefs.SetInt("High_climb",GameObject.Find("score").GetComponent<score>().Max_hight);
					PlayerPrefs.Save();
				}
			}
			death_code();
		}
		if(other.tag=="spike")
		{
			if(Application.loadedLevelName=="Dodge"){
				if(PlayerPrefs.GetInt("High_dodge")<GameObject.Find("Controller").GetComponent<Controller>().score){
					PlayerPrefs.SetInt("High_dodge",GameObject.Find("Controller").GetComponent<Controller>().score);
					PlayerPrefs.Save();
				}
			}
			death_code();
		}
		if(other.tag=="crusher")
		{
			death_code();
		}
		if(other.tag=="Robot")
		{
			death_code();
		}
		if(other.tag=="OverLimits")
		{
			death_code();
		}
		if(other.tag=="Horizontal_Thrust")//vertical
		{
			thrust_v=1;
			double_jump=true;
		}
		if(other.tag == "Horizontal_Thrust_Right")
		{
			moveDirection.y = Thust_h_vert_speed;
			thrust_h=1;
			double_jump=true;
		}
		if(other.tag == "Horizontal_Thrust_Left")
		{
			moveDirection.y = Thust_h_vert_speed;
			thrust_h=-1;
			double_jump=true;
		}
		if(other.tag == "h_static_platform"){
			other.SendMessageUpwards("StopOnPlayerStay",true);
		}
		
	}
	void OnTriggerExit (Collider other){
		if(other.tag=="D_jmp_edge_fix"){
			double_jump=true;
		}
		if(other.tag == "Platform")
		{
			transform.parent= null;
			other.SendMessageUpwards("tell_the_speed",true); //Enter platform-> tell the platform speed (to add momentum on exit)
			activate_momentum=1;//start adding momentum
		}
		if(other.tag=="Horizontal_Thrust")//vertical
		{
			thrust_v=0;
		}
		if(other.tag == "h_static_platform"){
			other.SendMessageUpwards("StopOnPlayerStay",false);
		}
	}
	void OnControllerColliderHit (ControllerColliderHit hit){
		thrust_h = 0;
		platform_speed=0;
		activate_momentum=0; //stop adding momentum
		if(hit.collider.tag!="treadmill")
		{
			treadmill_dir=0;
		}


	}
	void death_code(){
		if(Application.loadedLevelName=="Dodge" || Application.loadedLevelName=="Climb"){
			GameObject.Find("UI_Drawer").GetComponent<InGameUI>().Extras_death_menu();
			return;
		}
		if(hit_checkpoint)
			{	
				transform.parent=null;
				transform.position = checkpoint_pos;
				
				if(weight_act_platform!=null)
				{
					weight_act_platform.SendMessageUpwards("ResetPos",1);
				}
			}
			else{
				Application.LoadLevel(Application.loadedLevelName);
			}
	}
}    