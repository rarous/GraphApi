using System;
using System.Reflection;

namespace Facebook.GraphApi.Publishing {

  /// <summary>
  /// Link for publishing to wall.
  /// </summary>
  public class Link : FeedPublishingBase {

    /// <summary>
    /// Initializes a new instance of the Link class.
    /// </summary>
    /// <param name="graphApi"></param>
    public Link(Graph graphApi)
      : base(graphApi) {
    }

    /// <summary>
    /// Gets or sets the actual URL that was shared.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the name of the link.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the caption of the link.
    /// </summary>
    public string Caption { get; set; }

    /// <summary>
    /// Gets or sets a description of the link.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the optional message from the user about this link.
    /// </summary>
    public string Message { get; set; }

    protected override string GetKey(PropertyInfo property) {

      string key = property.Name.ToLower();

      if (key == "url") {
        return "link";
      }

      return key;
    }
  }
}
