//#define DEBUG
namespace CorruptedSmileStudio.Feeds
{
    using Utils;
    /// <summary>
    /// This class facilitates the parsing of RSS formatted feeds.
    /// </summary>
    public class RssFeed : BaseFeed
    {
        /// <summary>
        /// Initializes the rss feed class.
        /// </summary>
        /// <param name="feedLength">The number of feed items to load. If set to -1, it will attempt to load all of them.</param>
        public RssFeed(int feedLength)
            : base(feedLength)
        {
#if DEBUG
            UnityEngine.Debug.Log("Initialised RSS Feed");
#endif
        }
        /// <summary>
        /// Converts an XML feed into feed items.
        /// </summary>
        /// <param name="contents">The xml file contents. Usually obtained through WWW.</param>
        public override void Parse(string contents)
        {
            reader = new TinyXmlReader(contents);
            FeedItem feed;
            bool run = true;

            while (reader.Read("channel") && run)
            {
                feed = new FeedItem();
                while (reader.Read("item"))
                {
                    // Gets the item's title
                    if (reader.tagName == "title" && reader.isOpeningTag)
                    {
						if(reader.xmlString.Substring(reader.index +1, 10).Contains("<![CDATA["))
						{
							string content = reader.xmlString.Substring(reader.index+1);
							feed.Title = StripHTML(content.Substring(0, content.IndexOf("]]>")));
						}
                    }
                    // Gets the item's published date
                    else if (reader.tagName == "pubDate" && reader.isOpeningTag)
                    {
                        feed.SetDate(reader.content);
                    }
                    // Gets the item's link
                    else if (reader.tagName == "link" && reader.isOpeningTag)
                    {
                        feed.Link = reader.content;
                    }
                    // Gets the item's description
                    else if (reader.tagName == "description" && reader.isOpeningTag)
                    {
                        if (reader.xmlString.Substring(reader.index + 1, 10).Contains("<![CDATA["))
                        {
                            string content = reader.xmlString.Substring(reader.index + 1);
                            feed.Message = StripHTML(content.Substring(0, content.IndexOf("]]>")));
                        }
                        else
                        {
                            feed.Message = StripHTML(reader.content);
                        }
                    }
					else if (reader.tagName.StartsWith("img") && reader.isOpeningTag)
					{
						feed.ImageURL = reader.tagName.Substring(reader.tagName.IndexOf("h"), (reader.tagName.Length - reader.tagName.IndexOf("h"))-1);                 
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