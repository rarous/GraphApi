using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Publishing {

  /// <summary>
  /// Name-link pair class.
  /// </summary>
  public class NameLink {

    /// <summary>
    /// Initializes a new instance of the NameLink class.
    /// </summary>
    public NameLink(string name, string link) {
      Name = name;
      Link = link;
    }

    /// <summary>
    /// Gets or sets the name of action.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the link of action.
    /// </summary>
    [JsonProperty("link")]
    public string Link { get; set; }
  }
}
