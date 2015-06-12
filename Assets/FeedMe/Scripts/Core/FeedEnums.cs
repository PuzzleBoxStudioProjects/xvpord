namespace CorruptedSmileStudio.Feeds
{
    /// <summary>
    /// The type of feed to load.
    /// </summary>
    public enum FeedType
    {
        /// <summary>
        /// Attempts to automatically determine what type of feed is being loaded.
        /// </summary>
        auto,
        /// <summary>
        /// Attempts to load the feed as an ATOM feed.
        /// </summary>
        atom,
        /// <summary>
        /// Attempts to load the feed as a RSS feed.
        /// </summary>
        rss,
        /// <summary>
        /// Attempts to load the feed as the Simple Feed type of earlier versions.
        /// </summary>
        simple
    }
    /// <summary>
    /// The current state of FeedMe
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Ready to be used
        /// </summary>
        Ready,
        /// <summary>
        /// The feed is currently being updated.
        /// </summary>
        Updating,
        /// <summary>
        /// The feed should be updated.
        /// </summary>
        Update,
        /// <summary>
        /// An error has occurred when loading the feeds.
        /// </summary>
        Error
    }
}