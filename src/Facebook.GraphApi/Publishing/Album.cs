using System;

namespace Facebook.GraphApi.Publishing {

  /// <summary>
  /// Album for publishing to profile.
  /// </summary>
  public class Album : PublishingBase {

    /// <summary>
    /// Initializes a new instance of the Album class.
    /// </summary>
    /// <param name="graphApi"></param>
    public Album(Graph graphApi)
      : base(graphApi) {
    }

    /// <summary>
    /// Gets or sets the title of the album.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the album.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Publishes album to profile.
    /// </summary>
    /// <param name="profileId">Profile Id.</param>
    public void Publish(long profileId) {

      string path = String.Concat(profileId, AlbumsPath);
      Publish(path);
    }

    /// <summary>
    /// Publishes album to current users profile.
    /// </summary>
    public void Publish() {
      string path = String.Concat(CurrentUser, AlbumsPath);
      Publish(path);
    }
  }
}
