using UnityEngine;
namespace CorruptedSmileStudio.Feeds
{
    /// <summary>
    /// A component that hooks into FeedMe to provide the loaded feed as a Unity 4.6+ UI
    /// </summary>
    [RequireComponent(typeof(FeedMe))]
    public class UnityUIDisplay : MonoBehaviour
    {
        /// <summary>
        /// The GameObject that contains the feed display list
        /// </summary>
        [Tooltip("The GameObject that contains the feed display")]
        public GameObject feedDisplay;
        /// <summary>
        /// The Transform that will hold the feed items once they have loaded.
        /// </summary>
        [Tooltip("The Transform that will hold the feed items once they have loaded.")]
        public Transform feedDisplayList;
        /// <summary>
        /// The prefab that is used for each feed item.
        /// </summary>
        [Tooltip("The prefab that is used for each feed item.")]
        public GameObject feedDisplayItemPrefab;
        /// <summary>
        /// The text component of the button that displays the feed.
        /// </summary>
        [Tooltip("The text component of the button that displays the feed.")]
        public UnityEngine.UI.Text openButtonText;
        /// <summary>
        /// The text to display when a feed is loading.
        /// </summary>
        [Tooltip("The text to display when a feed is loading.")]
        public string loadingFeedsText = "Loading feeds...";

        private bool initialised = false;

        private FeedMe feedMe;
        private BaseFeed feed;

        void Awake()
        {
            feedMe = GetComponent<FeedMe>();
            feedMe.Updated += UnityUIDisplay_Updated;
            feedMe.PreUpdate += feedMe_PreUpdate;
        }

        void feedMe_PreUpdate(object sender, System.EventArgs e)
        {
            openButtonText.text = loadingFeedsText;
        }

        void UnityUIDisplay_Updated(object sender, System.EventArgs e)
        {
            feed = (BaseFeed)sender;
            openButtonText.text = feed.Items[0].Title;
            initialised = false;
            int count = feedDisplayList.childCount;
            for (int i = 0; i < count; i++)
            {
                Destroy(feedDisplayList.GetChild(i).gameObject);
            }
            if (feedDisplay.activeInHierarchy)
            {
                feedDisplay.SetActive(false);
                ShowFeedDisplay();
            }
        }

        /// <summary>
        /// Switches the visibility of the feeds. If it is currently visible, hide it. Else make it visible
        /// </summary>
        public void ShowFeedDisplay()
        {
            if (feedDisplay.activeInHierarchy)
            {
                feedDisplay.SetActive(false);
                return;
            }
            if (!initialised)
            {
                if (feed != null)
                {
                    GameObject go;
                    for (int i = 0; i < feed.Items.Count; i++)
                    {
                        go = (GameObject)Instantiate(feedDisplayItemPrefab);
                        go.transform.SetParent(feedDisplayList, false);
                        go.GetComponent<FeedItemDisplay>().Initialise(feed.Items[i]);
                    }
                    initialised = true;
                }
            }
            feedDisplay.SetActive(true);
        }
    }
}