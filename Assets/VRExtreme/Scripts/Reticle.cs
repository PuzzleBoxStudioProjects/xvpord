using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour 
{
	private RaycastHit 	hit;
	private Transform 	cameraObject;
	private Vector3 	origScale;
	private Camera 	  	camera;
	private float 		distance;	

	// Use this for initialization
	void Awake () 
	{
		XtremeManager.OnUpdate += new XtremeManager.XtremeUpdate(OnUpdate);
	}

	void OnDestroy()
	{
		XtremeManager.OnUpdate -= new XtremeManager.XtremeUpdate(OnUpdate);
	}
	// Update is called once per frame
	void OnUpdate () 
	{
		if(Physics.Raycast(cameraObject.transform.position, cameraObject.transform.rotation * Vector3.forward * 2f, out hit))
		{
			distance = hit.distance * .95f;
		}
		else
		{
			distance = camera.farClipPlane;
		}

		transform.position = cameraObject.transform.position + cameraObject.transform.rotation * Vector3.forward * (distance * .95f);
		transform.LookAt(cameraObject.transform.position);
		transform.Rotate(0,180f,0);
		transform.localScale = origScale * distance;
	}
}
