using UnityEngine;
using UnityEngine.UI;
using System.Collections;
namespace CorruptedSmileStudio.Feeds
{
    /// <summary>
    /// Used to represent FeedItems within Unity's new UI module.
    /// </summary>
    public class FeedItemDisplay : MonoBehaviour
    {
        /// <summary>
        /// The text component that will hold the title of the feed item.
        /// </summary>
        [Tooltip("The text component that will hold the title of the feed item.")]
        public Text title;
        /// <summary>
        /// The text component that will hold the date of the feed item.
        /// </summary>
        [Tooltip("The text component that will hold the date of the feed item.")]
        public Text date;
        /// <summary>
        /// The text component that will content the content of the feed item.
        /// </summary>
        [Tooltip("The text component that will content the content of the feed item.")]
        public Text content;
        /// <summary>
        /// The button that will be used to open the link of the feed item.
        /// </summary>
		///
        [Tooltip("The button that will be used to open the link of the feed item.")]
        public Button link;
		public GameObject imageTex;
		public GameObject background;
		public Shader shader;
		private bool   running;
        private string URL;
        /// <summary>
        /// Initialises the UI with the passed FeedItem's properties
        /// </summary>
        /// <param name="feedItem">The FeedItem that will be represented by the UI.</param>
        public void Initialise(FeedItem feedItem)
        {
	
            gameObject.SetActive(true);
            title.text = feedItem.Title;
            date.text = feedItem.Date.ToString();
            content.text = feedItem.Message;
            URL = feedItem.Link;
            link.onClick.AddListener(delegate()
            {
                Application.OpenURL(URL);
            });

			gameObject.SetActive(true);
			running = true;
			StartCoroutine(WaitForWWW(feedItem));          
        }

		public IEnumerator WaitForWWW(FeedItem item)
		{
			imageTex.GetComponent<Renderer>().material.mainTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
			while(true)
			{
				WWW www = new WWW(item.ImageURL);
				yield return www;
				www.LoadImageIntoTexture((Texture2D)imageTex.GetComponent<Renderer>().material.mainTexture);
				running = false;
			}		
		}
    }
}