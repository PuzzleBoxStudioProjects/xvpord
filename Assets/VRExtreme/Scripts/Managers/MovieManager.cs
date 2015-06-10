using UnityEngine;
using System.Collections;

public class MovieManager : MonoBehaviour 
{

	void Awake () 
	{
		XtremeManager.OnUpdate += new XtremeManager.XtremeUpdate(OnUpdate);
		Buttons.ButtonPressed += new Buttons.ButtonEvent(OnHit);
	}
	
	void OnDestroy()
	{
		XtremeManager.OnUpdate -= new XtremeManager.XtremeUpdate(OnUpdate);
		Buttons.ButtonPressed -= new Buttons.ButtonEvent(OnHit);
	}
	// Update is called once per frame
	void OnUpdate () 
	{
		
	}
	
	void OnHit(string name)
	{
		switch(name)
		{
		case "back":{Application.LoadLevel(0);}break;
		}
	}
}
