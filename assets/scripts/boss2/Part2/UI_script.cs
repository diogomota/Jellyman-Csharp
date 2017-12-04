using UnityEngine;
using System.Collections;

public class UI_script : MonoBehaviour {
public UIToolkit InGameMenu;
	private UIVerticalLayout v_container;
	private UIHorizontalLayout h_container;
	private UIButton next_lvl;
	private UIJoystick joystick;
	
	public GameObject Player;
	private Player_controll script;
	// Use this for initialization
	void Start () {
		float scale_factor=Screen.width/900f;
		// gain access to player script{
		script = Player.GetComponent<Player_controll>();
		//joystick
		joystick = UIJoystick.create(InGameMenu,"joystick.png",new Rect(0,2*(Screen.height/3),Screen.width/4,Screen.width/4),Screen.width/8,-(Screen.width/8));
		joystick.deadZone=new Vector2(.1f,.1f);
		joystick.positionFromBottomRight(0.1f,0.05f);
		joystick.allowTouchBeganWhenMovedOver=true;
		joystick.maxJoystickMovement=70f;
		joystick.highlightedTouchOffsets= new UIEdgeOffsets(120);
		
		//Pause & sound 
		var pause = UIButton.create(InGameMenu,"pause.png","pause_pressed.png",0,0);
		pause.setSize(pause.width*scale_factor,pause.height*scale_factor);
		pause.onTouchUpInside += pause_start;
		pause.positionFromTopRight(.01f,.01f);
		
		
		var names = new string[]{"sound_on.png","sound_off.png"};
		var sound = UIStateButton.create(InGameMenu,names,names,0,0);
		sound.setSize(sound.width*scale_factor,sound.height*scale_factor);
		sound.onStateChange += Sound_control;
		sound.positionFromTopRight(.01f,.12f);
		//to pass info between levels
		if(AudioListener.pause){
			sound.state=1;
		}
		
		//next lvl
		next_lvl = UIButton.create(InGameMenu,"next.png","next_pressed.png",0,0);
		next_lvl.setSize(next_lvl.width*scale_factor,next_lvl.height*scale_factor);
		next_lvl.onTouchUpInside += Go_to_next_lvl;
		next_lvl.hidden=true;
		
		//Paused interface
		var continue_btn = UIButton.create (InGameMenu,"continue.png","continue_pressed.png",0,0);
		continue_btn.setSize(continue_btn.width*scale_factor,continue_btn.height*scale_factor);
		continue_btn.centerize();
		continue_btn.onTouchUpInside += Resume_game;
		
		var main_menu = UIButton.create (InGameMenu,"main_menu.png","main_menu_pressed.png",0,0);
		main_menu.setSize(main_menu.width*scale_factor,main_menu.height*scale_factor);
		main_menu.onTouchUpInside += Go_to_Menu;
		
		var restart = UIButton.create (InGameMenu,"restart.png","restart_pressed.png",0,0);
		restart.setSize(restart.width*scale_factor,restart.height*scale_factor);
		restart.onTouchUpInside += Restart_game;
		
		h_container = new UIHorizontalLayout(Screen.width/19);
		h_container.addChild(main_menu,restart);
		
		v_container = new UIVerticalLayout(10);
		v_container.beginUpdates();
		v_container.addChild(continue_btn);
		v_container.pixelsFromCenter((int)(-continue_btn.height),(int)(-continue_btn.width/2));
		v_container.endUpdates();
		
		h_container.parentUIObject = v_container;
		h_container.pixelsFromTopLeft((int)(continue_btn.height),0);
		v_container.hidden=true;
		h_container.hidden=true;
	}
	void Update(){
		/*if(Input.touchCount==0){
			script.direction=0;
		}*/
		if(Input.GetKeyDown(KeyCode.Escape)){
			hardware_pause_start();
		}
#if !(UNITY_EDITOR) && !(UNITY_STANDALONE)
		script.V_dir=joystick.joystickPosition.y;
		script.H_dir=joystick.joystickPosition.x;
#endif
	}
	void Sound_control(UIStateButton sender,int state){//mute control
		if(state==0){
			AudioListener.pause=false;
		}
		if(state==1){
			AudioListener.pause=true;
		}
	}
	void pause_start(UIButton sender){
		Time.timeScale=0;
		v_container.hidden=false;
		h_container.hidden=false;
		joystick.hidden=true;
	}
	void hardware_pause_start(){
		Time.timeScale=0;
		v_container.hidden=false;
		h_container.hidden=false;
		joystick.hidden=true;
	}
	void Resume_game(UIButton sender){
		Time.timeScale=1;
		v_container.hidden=true;
		h_container.hidden=true;
		joystick.hidden=false;
	}
	void Go_to_Menu(UIButton sender){
		Time.timeScale=1;
		Application.LoadLevel(0);
	}
	void Restart_game(UIButton sender){
		Time.timeScale=1;
		Application.LoadLevel(Application.loadedLevel);
		
	}
	void Go_to_next_lvl(UIButton sender){
		Time.timeScale=1;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	public void next_lvl_menu(){
		Time.timeScale=0;
		h_container.beginUpdates();
		h_container.addChild(next_lvl);
		h_container.parentUIObject=null;
		h_container.refreshPosition();
		h_container.positionFromTopLeft(.4f,.33f);
		h_container.endUpdates();
		h_container.hidden=false;
		joystick.hidden=true;
	}
}
