using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi {

  public class Error {

    const string OAuthExceptionName = "OAuthException";

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    public void ThrowException() {
      if (Type == OAuthExceptionName) {
        throw new OAuthException(Message);
      }

      throw new GraphException(Type, Message);
    }
  }
}
