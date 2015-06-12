using UnityEngine;
using UnityEngine.UI;
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
        [Tooltip("The button that will be used to open the link of the feed item.")]
        public Button link;
        private string URL;
        /// <summary>
        /// Initialises the UI with the passed FeedItem's properties
        /// </summary>
        /// <param name="feedItem">The FeedItem that will be represented by the UI.</param>
        public void Initialise(FeedItem feedItem)
        {
            gameObject.SetActive(false);

            title.text = feedItem.Title;
            date.text = feedItem.Date.ToString();
            content.text = feedItem.Message;
            URL = feedItem.Link;
            link.onClick.AddListener(delegate()
            {
                Application.OpenURL(URL);
            });

            gameObject.SetActive(true);
        }
    }
}