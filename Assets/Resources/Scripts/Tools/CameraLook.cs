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

	void Start()
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

			string tag = hit.transform.tag;
			if(tag == "MenuButton" || tag == "VideoButton" || tag == "Video")
			{
				if(tag != "Video")
				{
					if(currentObject == null)
					{
						currentObject = hit.transform.gameObject;
					    Buttons buttons = currentObject.GetComponent<Buttons>();
						buttons.OnLook(true);
					}
					else if(currentObject != null && currentObject.name != hit.transform.name) 
					{
						currentObject.GetComponent<Buttons>().OnLook(false);
						currentObject = null;
					}
					else if(currentObject != null && currentObject.name == hit.transform.name)
					{

					}
				}
				else
				{

				}
			}
		}
		else
		{
		
			currentObject = null;
		}
	}
}
