using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Facebook.GraphApi {

  public static class Extensions {

    private const string FormUrlEncoded = "application/x-www-form-urlencoded";

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

      request.Method = httpVerb.ToString();
      return request;
    }

    public static void PostData(this HttpWebRequest request, IDictionary<string, object> data) {

      string postData = data.ToQueryString();
      byte[] postDataBytes = HttpUtility.UrlEncodeToBytes(postData);

      request.ContentType = FormUrlEncoded;
      request.ContentLength = postDataBytes.Length;

      // TODO: async
      using (var requestStream = request.GetRequestStream()) {
        requestStream.Write(postDataBytes, 0, postDataBytes.Length);
      }
    }

    public static string ReadResponse(this HttpWebRequest request) {
      // TODO: async
      using (var response = request.GetResponse())
      using (var reader = new StreamReader(response.GetResponseStream())) {
        return reader.ReadToEnd();
      }
    }

    public static string ToQueryString(this IDictionary<string, object> parameters) {
      return parameters.
        Select(NameValuePair).
        Aggregate(String.Empty, JoinPairs);
    }

    private static string NameValuePair(KeyValuePair<string, object> pair) {
      const string keyValueSeparator = "=";
      return String.Concat(pair.Key, keyValueSeparator, pair.Value);
    }

    private static string JoinPairs(string acc, string item) {
      const string pairsSeparator = "&";
      return String.Concat(acc, pairsSeparator, item);
    }

    public static Uri ToUri(this string url) {
      return new Uri(url);
    }

    public static Uri ToUri(this string url, IDictionary<string, object> args) {
      return AppendGetParameters(url.ToUri(), args);
    }
  }
}
