using UnityEngine;
using System.Collections;

public class CameraLook : MonoBehaviour 
{
	public delegate void HitEvent(string name);
	public static event HitEvent OnHit;


	private GameObject 	centerEyeObject;
	private GameObject 	currentObject;
	private RaycastHit 	hit;

	private bool 		canSelect;


	void Awake()
	{
		XtremeManager.OnUpdate += new XtremeManager.XtremeUpdate(OnUpdate);
	}

	void OnDestroy()
	{
		XtremeManager.OnUpdate -= new XtremeManager.XtremeUpdate(OnUpdate);
	}

	void OnStart()
	{
		centerEyeObject = GameObject.Find("RightEyeAnchor");
	}
	// Update is called once per frame
	void OnUpdate () 
	{
		if(Physics.Raycast(centerEyeObject.transform.position, centerEyeObject.transform.forward, out hit))
		{
			if(OnHit != null)
				OnHit(hit.transform.name);

		

			if(currentObject != null && currentObject.transform.name != hit.transform.name)
			{
				if(currentObject.transform.tag == "buttons")
				{
					Buttons buttons = currentObject.GetComponent<Buttons>();
					buttons.OnLook(false);
				}
			}
			else 
			{
				if(currentObject.transform.tag == "button")
				{
					currentObject = hit.transform.gameObject;
					Buttons buttons = currentObject.GetComponent<Buttons>();
					buttons.OnLook(true);
				}	
			}
		}
		else
		{
		
			currentObject = null;
		}
	}
}
