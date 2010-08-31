using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi {

  /// <summary>
  /// Error response class.
  /// </summary>
  public class Error {
    
    /// <summary>
    /// Gets or sets the type of exception.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// Throws exception with this error.
    /// </summary>
    public void ThrowException() {
      if (String.Compare(Type, typeof(OAuthException).Name, StringComparison.InvariantCultureIgnoreCase) == 0) {
        throw new OAuthException(Message);
      }

      throw new GraphException(Type, Message);
    }
  }
}
