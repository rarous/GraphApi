using System;

namespace Facebook.GraphApi.Publishing {

  /// <summary>
  /// Base type for entities publishing to wall.
  /// </summary>
  public abstract class FeedPublishingBase : PublishingBase {

    /// <summary>
    /// Initializes a new instance of the FeedPublishingBase class.
    /// </summary>
    /// <param name="graphApi"></param>
    protected FeedPublishingBase(Graph graphApi)
      : base(graphApi) {
    }

    /// <summary>
    /// Publishes to profile's wall.
    /// </summary>
    /// <param name="profileId">Profile Id.</param>
    public void Publish(long profileId) {

      string path = String.Concat(profileId, FeedPath);
      Publish(path);
    }

    /// <summary>
    /// Publishes to current user's wall.
    /// </summary>
    public void Publish() {
      string path = String.Concat(CurrentUser, FeedPath);
      Publish(path);
    }
  }
}
