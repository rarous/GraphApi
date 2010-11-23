namespace Facebook.GraphApi {

  using System;
  using System.IO;
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;

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

    public static string ToJson<T>(this T obj) where T : class {
      var serializer = new JsonSerializer();
      var writer = new StringWriter();

      try {
        serializer.Serialize(writer, obj);
        return writer.ToString();
      }
      catch (JsonSerializationException) {
        return null;
      }
      finally {
        if (writer != null) {
          writer.Dispose();
        }
      }
    }
  }
}
