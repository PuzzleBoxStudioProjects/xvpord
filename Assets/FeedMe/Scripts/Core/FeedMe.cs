using UnityEngine;
using System;
using System.Collections.Generic;

namespace CorruptedSmileStudio.Feeds
{
    /// <summary>
    /// The displayer and xml feeder to the Feed classes.
    /// </summary>
    public class FeedMe : MonoBehaviour
    {
        #region Variables
        #region URL
        /// <summary>
        /// The URL where the feed it located.
        /// </summary>
        [Tooltip("The URL to load the feed from.")]
        public string feedURL = "";
        #endregion
        #region Feed Variables
        /// <summary>
        /// The type of feed to load.
        /// Auto will try to detect what type of feed it is.
        /// </summary>
        [Tooltip("The format the feed is expected to be in.")]
        public FeedType type = FeedType.simple;
        /// <summary>
        /// Whether the system must only update the feeds once or regularly.
        /// </summary>
        [Tooltip("Update the feed only once per a scene load")]
        public bool updateOnce = false;
        /// <summary>
        /// Time between updates.
        /// </summary>
        [Tooltip("Update the feed after the specified time if updateOnce is false.")]
        public int minutesToUpdate = 60;
        /// <summary>
        /// The number of items to load.
        /// </summary>
        [Tooltip("The number of feed items to load.")]
        public int feedLength = 10;
        /// <summary>
        /// The time when the last update was done.
        /// </summary>
        private float lastUpdateTime = 0f;
        /// <summary>
        /// The feed to be created.
        /// </summary>
        [System.NonSerialized]
        public BaseFeed feed;
        /// <summary>
        /// The status of the feed.
        /// </summary>
        [System.NonSerialized]
        [HideInInspector]
        public Status feedStatus;
        /// <summary>
        /// The text to use as the text if the feed cannot be loaded.
        /// </summary>
        [Tooltip("The text to display as the title when there is an error loading a feed.")]
        public string errorMessageText = "Error loading feed...";
        #endregion
        #endregion
        #region Events
        /// <summary>
        /// Event that is fired when the feed gets updated.
        /// </summary>
        public event FeedUpdated Updated;
        /// <summary>
        /// Event that is fired when the feed is about to be updated.
        /// </summary>
        public event FeedUpdated PreUpdate;
        #endregion

        #region Standard Methods
        void Start()
        {
            // Create a Feed based upon which option was selected.
            // Auto gets set when GetFeed() is called.
            switch (type)
            {
                case FeedType.simple:
                    feed = new SimpleFeed(feedLength);
                    break;
                case FeedType.rss:
                    feed = new RssFeed(feedLength);
                    break;
                case FeedType.atom:
                    feed = new AtomFeed(feedLength);
                    break;
                default:
                    break;
            }
            RefreshFeed();
        }

        void FixedUpdate()
        {
            // If it is set to update once per load, skips the following code.
            if (updateOnce)
                return;
            // Checks the time to determine whether the feed needs updating.
            if ((Time.time >= lastUpdateTime) && (feedStatus == Status.Ready || feedStatus == Status.Error))
            {
                RefreshFeed();
            }
        }
        #endregion
        #region Custom Functions
        /// <summary>
        /// Gets the XML document from the feedURL.
        /// Then uses the Feed class to parse it.
        /// </summary>
        /// <returns>A wait.</returns>
        public System.Collections.IEnumerator GetFeed()
        {
            if (feedStatus == Status.Update)
            {
                // If the feed has been created, clear it.
                if (feed != null)
                    feed.Clear();
                feedStatus = Status.Updating;
                OnPreUpdate();

                WWW www = new WWW(feedURL);
                yield return www;

                // If no errors were found parse feed.
                if (www.error == null)
                {
                    if (type == FeedType.auto)
                    {
                        // Checks to see if it is a RSS feed
                        if (www.text.Contains("<rss"))
                        {
                            feed = new RssFeed(feedLength);
                        }
                        // Checks to see if it is a ATOM feed.
                        else if (www.text.Contains("<feed xmlns"))
                        {
                            feed = new AtomFeed(feedLength);
                        }
                        else
                        {
                            feed = new SimpleFeed(feedLength);
                        }
                    }
                    feed.Parse(www.text);
                    feedStatus = Status.Ready;
                }
                else
                {
                    if (feed == null)
                        feed = new SimpleFeed(1);
                    // sets all the error messages
                    feedStatus = Status.Error;
                    FeedItem item = new FeedItem(errorMessageText, www.error, "", "", DateTime.Now);
                    feed.Items.Add(item);
                    Debug.LogError(www.error);
                }
                lastUpdateTime = Time.time + (60f * minutesToUpdate);
                www.Dispose();
                GC.Collect();
                OnUpdated();
            }
        }
        /// <summary>
        /// Refreshes the feed.
        /// </summary>
        public void RefreshFeed()
        {
            // Sets the update feed to true.
            feedStatus = Status.Update;
            // Starts the GetFeed Coroutine
            StartCoroutine(GetFeed());
        }
        /// <summary>
        /// Fires the Updated event.
        /// </summary>
        public void OnUpdated()
        {
            if (Updated != null)
            {
                Updated(feed, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Fires the PreUpdate event.
        /// </summary>
        public void OnPreUpdate()
        {
            if (PreUpdate != null)
            {
                PreUpdate(feed, EventArgs.Empty);
            }
        }
        #endregion
    }
    public delegate void FeedUpdated(object sender, EventArgs e);
}