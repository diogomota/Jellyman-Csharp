using UnityEngine;
using System.Collections;

public class UI_info_text : MonoBehaviour {
	public UIToolkit Text;
	public UITextInstance text1,text2,text3;
	// Use this for initialization
	void Start () {
		var text = new UIText(Text,"font","font.png");
		
		text1 = text.addTextInstance("",0,0);
		text1.textScale=Screen.width/1200f;
		text1.positionFromTopLeft(0,0);
		text1.hidden=true;
		if(Application.loadedLevelName=="level_1"){
			text2 = text.addTextInstance("left      right",0,0);
			text2.textScale=Screen.width/900f;
			text2.positionFromBottomLeft(0,0);
			
			text3 = text.addTextInstance("jump",0,0);
			text3.textScale=Screen.width/900f;
			text3.positionFromBottomRight(0,0);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.loadedLevelName=="level_1"){
			if(!text1.hidden){
				hide_controll_aid();
			}
		}
	}
	void hide_controll_aid(){
		text2.hidden=true;
		text3.hidden=true;
	}
}
