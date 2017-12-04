using UnityEngine;
using System.Collections;

public class GUI_text_menu : MonoBehaviour {
	public UIToolkit Text;
	public UITextInstance text1,text2, text3, text4;
	private Draw_UI script;
	
	// Use this for initialization
	void Start () {
		script = GameObject.Find("Draw_UI").GetComponent<Draw_UI>();
		if(!PlayerPrefs.HasKey("High_dodge")){
				PlayerPrefs.SetInt("High_dodge",0);
				PlayerPrefs.Save();
			}
		if(!PlayerPrefs.HasKey("High_climb")){
				PlayerPrefs.SetInt("High_climb",0);
				PlayerPrefs.Save();
			}
		if(!PlayerPrefs.HasKey("High_shoot")){
				PlayerPrefs.SetInt("High_shoot",0);
				PlayerPrefs.Save();
			}
		
		
		var text = new UIText(Text,"font","font.png");
			
		text1 = text.addTextInstance("HighScores:",0f,0f);
		text1.positionFromTopLeft(.5f,0f);
		text1.textScale=Screen.width/900f;
			
		text2 = text.addTextInstance (""+PlayerPrefs.GetInt("High_dodge"),0f,0f);
		text2.positionFromTopLeft(0.5f,.21f);
		text2.textScale=Screen.width/900f;
		
		text3 = text.addTextInstance(""+PlayerPrefs.GetInt("High_shoot"),0f,0f);
		text3.positionFromTopLeft(.5f,.41f);
		text3.textScale=Screen.width/900f;
		
		text4 = text.addTextInstance(""+PlayerPrefs.GetInt("High_climb"),0f,0f);
		text4.positionFromTopLeft(.5f,.61f);
		text4.textScale=Screen.width/900f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(script.state==3){
			text1.hidden=false;
			text2.hidden=false;
			text3.hidden=false;
			text4.hidden=false;
		}else{
			text1.hidden=true;
			text2.hidden=true;
			text3.hidden=true;
			text4.hidden=true;
		}
		
	}
}
