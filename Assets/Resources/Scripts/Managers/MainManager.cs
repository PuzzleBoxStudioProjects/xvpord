using UnityEngine;
using System.Collections;

public class MainManager : MonoBehaviour {

	// Use this for initialization
	void Awake () 
	{
		XtremeManager.OnUpdate += new XtremeManager.XtremeUpdate(OnUpdate);
		Buttons.ButtonPressed += new Buttons.ButtonEvent(ButtonHit);
	}

	void OnDestroy()
	{
		XtremeManager.OnUpdate -= new XtremeManager.XtremeUpdate(OnUpdate);
		Buttons.ButtonPressed -= new Buttons.ButtonEvent(ButtonHit);
	}

	// Update is called once per frame
	void OnUpdate () 
	{
	
	}

	void ButtonHit(string name)
	{

		switch(name)
		{
		case "movies":{Application.LoadLevel(2);}break;
		case "media": {Application.LoadLevel(3);}break;
		case "events":{Application.LoadLevel(4);}break;
		case "exit":{Application.Quit();break;}
		}
	}
}
