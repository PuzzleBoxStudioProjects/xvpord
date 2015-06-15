using UnityEngine;
using System.Collections;

public class XtremeManager : MonoBehaviour 
{

	public static XtremeManager instance;

	public delegate void XtremeUpdate();
	public static event XtremeUpdate OnUpdate;


	// Use this for initialization
	void Awake () 
	{
		if(instance != null)
			Destroy (this.gameObject);
		else
			instance = this;
	
		Cursor.visible = false;
	}

	void Start()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	void OnDestroy()
	{
		Cursor.visible = true;
	}
	// Update is called once per frame
	void Update () 
	{
		if(OnUpdate != null)
			OnUpdate();

		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
}
