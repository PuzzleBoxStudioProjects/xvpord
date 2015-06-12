namespace CorruptedSmileStudio.Feeds
{
    using CorruptedSmileStudio.Utils;
    /// <summary>
    /// This class facilitates the parsing of the earlier custom formatted feeds.
    /// </summary>
    public class SimpleFeed : BaseFeed
    {
        /// <summary>
        /// Initialises the feed class.
        /// </summary>
        /// <param name="feedLength">The number of feed items to load. If set to -1, it will load all items.</param>
        public SimpleFeed(int feedLength)
            : base(feedLength)
        {
            UnityEngine.Debug.Log("Initialised Simple Feed");
        }
        /// <summary>
        /// Converts an XML feed into a list of FeedItem classes.
        /// </summary>
        /// <param name="contents">The XML feed data. Usually obtained through WWW.</param>
        public override void Parse(string contents)
        {
            reader = new TinyXmlReader(contents);
            FeedItem feed;
            bool run = true;

            while (reader.Read("Feeds") && run)
            {
                feed = new FeedItem();
                while (reader.Read("Feed"))
                {
                    // Gets the item's Title
                    if (reader.tagName == "Title" && reader.isOpeningTag)
                    {
                        feed.Title = reader.content;
                    }
                    // Gets the item's Date
                    else if (reader.tagName == "Date" && reader.isOpeningTag)
                    {
                        feed.SetDate(reader.content);
                    }
                    // Gets the item's Link
                    else if (reader.tagName == "Link" && reader.isOpeningTag)
                    {
                        feed.Link = reader.content;
                    }
                    // Gets the item's Message
                    else if (reader.tagName == "Message" && reader.isOpeningTag)
                    {
                        feed.Message = reader.content;
                    }
                }
                items.Add(feed);
                // Checks to see if it must load all items or a specific amount.
                if (numberOfItemsToLoad != -1 && items.Count > numberOfItemsToLoad - 1)
                {
                    run = false;
                }
            }
        }
    }
}