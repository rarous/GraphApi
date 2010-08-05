using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook.GraphApi.Publishing {

  /// <summary>
  /// Post for publishing to wall.
  /// </summary>
  public class Post {

    const string FeedPath = "/feed";

    readonly Graph graphApi;

    /// <summary>
    /// Initializes a new instance of the Post class.
    /// </summary>
    /// <param name="graphApi"></param>
    public Post(Graph graphApi) {
      this.graphApi = graphApi;
    }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the link to the picture included with this post.
    /// </summary>
    public string Picture { get; set; }

    /// <summary>
    /// Gets or sets the link attached to this post.
    /// </summary>
    public string Link { get; set; }

    /// <summary>
    /// Gets or sets the name of the link.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the caption of the link.
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// A description of the link
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the source link attached to this post.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Publishes post to profile's wall.
    /// </summary>
    /// <param name="profileId">Profile Id.</param>
    public void Publish(long profileId) {

      string path = String.Concat(profileId, FeedPath);
      var arguments = GetRequestArguments();

      graphApi.Post(path, arguments);
    }

    public void Publish() {
      string path = String.Concat("/me", FeedPath);
      var arguments = GetRequestArguments();

      graphApi.Post(path, arguments);
    }

    private IDictionary<string, object> GetRequestArguments() {

      return (from property in GetType().GetProperties()
              let key = property.Name.ToLower()
              let value = property.GetValue(this, null)
              select new { key, value }).
              ToDictionary(x => x.key, x => x.value);
    }
  }
}

