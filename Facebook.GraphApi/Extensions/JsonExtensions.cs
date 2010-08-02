using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Facebook.GraphApi {

  public static class JsonExtensions {

    public static JObject HandleError(this JObject response) {
      var error = response.Deserialize<Error>();
      if (error != null) {
        error.ThrowException();
      }
      return response;
    }

    public static T Deserialize<T>(this JObject source) where T : class {
      var serializer = new JsonSerializer();
      var reader = source.CreateReader();

      try {
        return serializer.Deserialize<T>(reader);
      }
      catch (JsonSerializationException) {
        return null;
      }
    }
  }
}
