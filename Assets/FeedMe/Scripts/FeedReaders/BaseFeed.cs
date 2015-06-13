#define DEBUG
namespace CorruptedSmileStudio.Feeds
{
    using UnityEngine;
    using System.Collections.Generic;
    using CorruptedSmileStudio.Utils;

    /// <summary>
    /// This class represents a XML based feed with all elements in a FeedItem list.
    /// </summary>
    public abstract class BaseFeed
    {
        /// <summary>
        /// The list of feed items
        /// </summary>
        protected List<FeedItem> items;
        /// <summary>
        /// The XML reader.
        /// </summary>
        protected TinyXmlReader reader;
        /// <summary>
        /// The number of items to load.
        /// </summary>
        protected int numberOfItemsToLoad = 10;

        /// <summary>
        /// Initialises the Feed class and number of items to load.
        /// </summary>
        /// <param name="feedLength">The number of feeds to load. If set to -1, loads all feeds.</param>
        public BaseFeed(int feedLength)
        {
            if (feedLength != -1)
                items = new List<FeedItem>(feedLength);
            else
                items = new List<FeedItem>(10);
            numberOfItemsToLoad = feedLength;
        }
        /// <summary>
        /// Converts a string into a list of feed items.
        /// </summary>
        /// <param name="contents">Usually the text returned by a WWW request to a feed.</param>
        public abstract void Parse(string contents);
        /// <summary>
        /// Returns a list of all the feed items.
        /// </summary>
        public List<FeedItem> Items
        {
            get
            {
                return items;
            }
        }
        /// <summary>
        /// Clears the feed items.
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }
        /// <summary>
        /// Removes all html from the feed content.
        /// </summary>
        /// <param name="line">The text to remove html from</param>
        /// <returns>A string without html and with line breaks converted to new line characters</returns>
        internal static string StripHTML(string line)
        {
            string[,] replacement = new string[,] {
            { "&amp;", "&" }, { "&lt;", "<" }, { "&gt;", ">" },
            { "&nbsp;", " " }, { "</li>", "\n" }, { "&#8230;", "..." },
            { "<br />", "\n" }, { "<br>", "\n" }, { "<br/>", "\n" },
            { "</ul>", "\n" }, { "<li>", "- " }, { "&#8217;", "'" },
            { "&#8212;", "-" }, { "&#8220;", "“" }, { "</p>", "\n" },
            { "&#8221;", "”" }, { "<![CDATA[", "" },{ "]]>", "" },
            { "<b>", "[b]" }, { "</b>", "[/b]" },
            };

            System.Text.StringBuilder sb = new System.Text.StringBuilder(line);

            for (int i = 0; i < replacement.GetLength(0); i++)
            {
                sb = sb.Replace(replacement[i, 0], replacement[i, 1]);
            }

            char[] array = new char[sb.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < sb.Length; i++)
            {
                char let = sb[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex++] = let;
                }
            }
            line = new string(array, 0, arrayIndex);
            char[] removal = new char[] { '\n', ' ' };

            return line.Trim(removal).Replace("[b]", "<b>").Replace("[/b]", "</b>");
        }
    }
}