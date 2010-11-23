namespace Facebook.GraphApi.Publishing {

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Reflection;

  /// <summary>
  /// Base type for publishing entities.
  /// </summary>
  public abstract class PublishingBase {

    public const string FeedPath = "/feed";
    public const string AlbumsPath = "/albums";
    public const string PhotosPath = "/photos";
    public const string CurrentUser = "/me";

    readonly Graph graphApi;

    /// <summary>
    /// Initializes a new instance of the PublishingBase class.
    /// </summary>
    /// <param name="graphApi"></param>
    protected PublishingBase(Graph graphApi) {
      this.graphApi = graphApi;
    }

    /// <summary>
    /// Publishes entity properties to specified Graph API path.
    /// </summary>
    /// <param name="path"></param>
    protected void Publish(string path) {
      var arguments = GetRequestArguments();

      graphApi.Post(path, arguments);
    }

    IDictionary<string, object> GetRequestArguments() {

      var properties = GetType().GetProperties();
      var query = from property in properties
                  let key = GetKey(property)
                  let value = GetValue(property)
                  select new { key, value };

      return query.ToDictionary(x => x.key, x => x.value);
    }

    /// <summary>
    /// Gets key of entity property for request parameter.
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    protected virtual string GetKey(PropertyInfo property) {

      return property.Name.ToLower();
    }

    /// <summary>
    /// Gets value of entity property for request parameter.
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    protected virtual object GetValue(PropertyInfo property) {

      return property.GetValue(this, null);
    }
  }
}
