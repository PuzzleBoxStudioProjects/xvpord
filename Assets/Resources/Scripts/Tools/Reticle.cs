using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour 
{
	private RaycastHit 	hit;
	private Transform 	cameraObject;
	private Vector3 	origScale;
	private Camera 	  	lookCamera;
	private float 		distance;	

	// Use this for initialization
	void Awake () 
	{
		XtremeManager.OnUpdate += new XtremeManager.XtremeUpdate(OnUpdate);
	}
	void Start()
	{

		cameraObject = GameObject.Find("RightEyeAnchor").GetComponent<Transform>()as Transform;
		lookCamera = cameraObject.GetComponent<Camera>();
		origScale = this.transform.localScale;
	}
	void OnDestroy()
	{
		XtremeManager.OnUpdate -= new XtremeManager.XtremeUpdate(OnUpdate);
	}
	// Update is called once per frame
	void OnUpdate () 
	{
		if(Physics.Raycast(cameraObject.transform.position, cameraObject.transform.rotation * Vector3.forward * 3f, out hit))
		{
			if(hit.transform.tag != "ignore")
			{

				distance = hit.distance * .65f;
			}
			else
			{

			}
		}
		else
		{
			distance = lookCamera.farClipPlane;
		}

		transform.position = cameraObject.transform.position + cameraObject.transform.rotation * Vector3.forward * (distance * .55f);
		transform.LookAt(cameraObject.transform.position);
		transform.Rotate(0,180f,0);

	}
}
