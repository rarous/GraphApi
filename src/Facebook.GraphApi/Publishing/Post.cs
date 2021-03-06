namespace Facebook.GraphApi.Publishing {

  using System;
  using System.Reflection;

  /// <summary>
  /// Post for publishing to wall.
  /// </summary>
  public class Post : FeedPublishingBase {

    /// <summary>
    /// Initializes a new instance of the Post class.
    /// </summary>
    /// <param name="graphApi"></param>
    public Post(Graph graphApi)
      : base(graphApi) {
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
    /// Gets or sets the list of available actions on the post.
    /// </summary>
    public NameLink[] Actions { get; set; }

    /// <inheritdoc />
    protected override object GetValue(PropertyInfo property) {
      if (property.Name == "Actions" && Actions != null) {
        return Actions.ToJson();
      }
      return base.GetValue(property);
    }
  }
}