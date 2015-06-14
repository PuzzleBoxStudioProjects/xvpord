using UnityEngine;
using System.Collections;
namespace CorruptedSmileStudio.Feeds
{
	/// <summary>
	/// A component that hooks into FeedMe to provide the loaded feed as a Unity 4.6+ UI
	/// </summary>
	[RequireComponent(typeof(FeedMe))]
	public class FeedDisplay : MonoBehaviour 
	{
		public GameObject RedbullPrefab;
		public GameObject parentObject;

		private BaseFeed baseFeed;	
		private FeedMe   feedMe;
		private Status   status;
		private bool 	 initialized;

		void Awake()
		{
			feedMe = GetComponent<FeedMe>();
			feedMe.Updated += FeedUpdate;
		}
		// Use this for initialization
		void Start () 
		{
		
		}
		
		// Update is called once per frame
		void FeedUpdate (object sender, System.EventArgs e) 
		{
			if(feedMe.feedStatus == Status.Ready)
			{
				baseFeed = (BaseFeed)sender;

				if(!initialized)
				{
					if(baseFeed != null)
					{
						for(int i = 0; i < baseFeed.Items.Count;i++)
						{
							GameObject clone;
							clone = Instantiate(RedbullPrefab, new Vector3(.5f,(i * -3),+7), Quaternion.identity) as GameObject;
							clone.transform.SetParent(parentObject.transform);
							clone.GetComponent<FeedItemDisplay>().Initialise(baseFeed.Items[i]);
						}


					}
				}
			}		
		}
	}

}