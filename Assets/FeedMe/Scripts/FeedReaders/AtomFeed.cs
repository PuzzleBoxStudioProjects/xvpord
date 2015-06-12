namespace CorruptedSmileStudio.Feeds
{
    using Utils;
    /// <summary>
    /// This class facilitates the parsing of ATOM formatted feeds.
    /// </summary>
    public class AtomFeed : BaseFeed
    {
        /// <summary>
        /// Initialises the ATOM feed class.
        /// </summary>
        /// <param name="feedLength">The number of feed items to load. If set to -1, it will attempt to load all items.</param>
        public AtomFeed(int feedLength)
            : base(feedLength)
        {
            UnityEngine.Debug.Log("Initialised ATOM Feed");
        }
        /// <summary>
        /// Converts an XML feed into feed items
        /// </summary>
        /// <param name="contents">The contents of the feed document. Usually obtained through WWW.</param>
        public override void Parse(string contents)
        {
            reader = new TinyXmlReader(contents);
            FeedItem feed;
            bool run = true;

            while (reader.Read("feed") && run)
            {
                feed = new FeedItem();
                while (reader.Read("entry"))
                {
                    // Gets the item's title
                    if (reader.tagName == "title type='text'" && reader.isOpeningTag)
                    {
                        feed.Title = reader.content;
                    }
                    // Gets the item's updated date
                    else if (reader.tagName == "updated" && reader.isOpeningTag)
                    {
                        feed.SetDate(reader.content);
                    }
                    // Gets the item's link
                    else if (reader.tagName.Contains("link rel='alter") && reader.isOpeningTag)
                    {
                        string link = reader.tagName.Substring(reader.tagName.IndexOf("href='") + 6);
                        feed.Link = link.Substring(0, link.IndexOf('\''));
                    }
                    // Gets the item's content
                    else if (reader.tagName == "content type='html'" && reader.isOpeningTag)
                    {
                        feed.Message = StripHTML(reader.content);
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