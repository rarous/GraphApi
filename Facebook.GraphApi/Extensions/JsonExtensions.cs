using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Facebook.GraphApi {

  public static class JsonExtensions {
    
    const string Error = "error";

    public static JObject HandleError(this JObject response) {
      var error = response[Error];
      if (error != null) {
        error.Deserialize<Error>().ThrowException();
      }
      return response;
    }

    public static T Deserialize<T>(this JToken source) where T : class {
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
