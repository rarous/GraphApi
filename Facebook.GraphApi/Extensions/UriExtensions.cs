using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Facebook.GraphApi {

  public static class UriExtensions {

    public static JObject MakeJsonRequest(this Uri url, HttpVerb httpVerb, IDictionary<string, object> args) {

      string response = url.MakeRequest(httpVerb, args);

      return JObject.Parse(response);
    }

    public static string MakeRequest(this Uri url, HttpVerb httpVerb, IDictionary<string, object> args) {

      if (httpVerb == HttpVerb.Get) {
        url = AppendGetParameters(url, args);
      }

      HttpWebRequest request = CreateWebRequest(url, httpVerb);

      if (httpVerb == HttpVerb.Post) {
        request.PostData(args);
      }

      try {
        return request.ReadResponse();
      }
      catch (WebException ex) {
        throw new GraphException("Error with API call.", ex);
      }
    }

    private static Uri AppendGetParameters(this Uri url, IDictionary<string, object> args) {

      if (args.Keys.Any()) {
        return new Uri(String.Concat(url, "?", args.ToQueryString()));
      }

      return url;
    }

    private static HttpWebRequest CreateWebRequest(Uri url, HttpVerb httpVerb) {

      var request = WebRequest.Create(url) as HttpWebRequest;

      request.AllowAutoRedirect = true;
      request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
      request.Method = httpVerb.ToString();

      return request;
    }

    public static Uri ToUri(this string url) {
      return new Uri(url);
    }

    public static Uri ToUri(this string url, IDictionary<string, object> args) {
      return AppendGetParameters(url.ToUri(), args);
    }
  }
}
