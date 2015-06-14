namespace CorruptedSmileStudio.Feeds
{
    using UnityEngine;
    /// <summary>
    /// Represents an entry in a feed.
    /// </summary>
    public class FeedItem
    {
		string imageURL;
        /// <summary>
        /// The title of the item
        /// </summary>
        string title;
        /// <summary>
        /// The link of the item.
        /// </summary>
        string link;
        /// <summary>
        /// The content/summary/description of the item.
        /// </summary>
        string message;
        /// <summary>
        /// The date it was published in DateTime format
        /// </summary>
        System.DateTime date;
		public string ImageURL
		{
			get{ return imageURL;}
			set{ imageURL = value;}
		}
        /// <summary>
        /// The title of the feed entry.
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        /// <summary>
        /// The link to the feed entry.
        /// </summary>
        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }
        /// <summary>
        /// The content/summary/description of the feed entry
        /// </summary>
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
        /// <summary>
        /// The date the feed entry was published in DateTime format.
        /// </summary>
        public System.DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        /// <summary>
        /// Initialise a new FeedItem
        /// </summary>
        public FeedItem()
        {
            Title = "";
            Link = "";
            Message = "";
			ImageURL = " ";
            Date = new System.DateTime();
        }
        /// <summary>
        /// Initialise a new FeedItem
        /// </summary>
        /// <param name="title">The title of the feed item</param>
        /// <param name="message">The message content of the feed item</param>
        /// <param name="link">The url to the item</param>
        /// <param name="date">The date it was published</param>
        public FeedItem(string title, string message, string imageUrl, string link, System.DateTime date)
        {
			ImageURL = imageUrl;
            Title = title;
            Message = message;
            Link = link;
            Date = date;
        }
        /// <summary>
        /// Converts a string into a DateTime and sets the item's Date to it.
        /// </summary>
        /// <param name="line">The date time in string.</param>
        public void SetDate(string line)
        {
            Date = System.Convert.ToDateTime(line);
        }
    }
}