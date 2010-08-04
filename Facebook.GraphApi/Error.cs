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
      if (String.Compare(Type, OAuthExceptionName) == 0) {
        throw new OAuthException(Message);
      }

      throw new GraphException(Type, Message);
    }
  }
}
