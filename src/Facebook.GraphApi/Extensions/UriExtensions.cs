namespace Facebook.GraphApi {

  using System;
  using System.Collections.Generic;
  using System.Collections.Specialized;
  using System.Linq;
  using System.Net;
  using System.Web;
  using Newtonsoft.Json.Linq;

  /// <summary>
  /// URI extensions.
  /// </summary>
  public static class UriExtensions {

    const string Delete = "DELETE";
    const string QuerySeparator = "?";
    const string UserAgent = "Facebook.GraphApi .net library (http://github.com/rarous/GraphApi)";
    const string WebExceptionMessage = "Error with API call.";

    /// <summary>
    /// Makes request to given URL. Result is JSON deserialized as <see cref="JObject"/>.
    /// </summary>
    /// <param name="url">URL of request target.</param>
    /// <param name="httpVerb">HTTP verb of request.</param>
    /// <param name="args">Request arguments.</param>
    /// <returns></returns>
    public static JObject MakeJsonRequest(this Uri url, HttpVerb httpVerb, IDictionary<string, object> args) {

      string response = url.MakeRequest(httpVerb, args);

      return JObject.Parse(response);
    }

    /// <summary>
    /// Makes request to given URL. Result is URL encoded from data parset to <see cref="NameValueCollection."/>.
    /// </summary>
    /// <param name="url">URL of request target.</param>
    /// <param name="httpVerb">HTTP verb of request.</param>
    /// <param name="args">Request arguments.</param>
    /// <returns></returns>
    public static NameValueCollection MakeNameValueRequest(this Uri url, HttpVerb httpVerb, IDictionary<string, object> args) {
      
      string response = url.MakeRequest(httpVerb, args);

      return HttpUtility.ParseQueryString(response);
    }

    /// <summary>
    /// Makes request to given URL. Result is raw text.
    /// </summary>
    /// <param name="url">URL of request target.</param>
    /// <param name="httpVerb">HTTP verb of request.</param>
    /// <param name="args">Request arguments.</param>
    /// <returns></returns>
    public static string MakeRequest(this Uri url, HttpVerb httpVerb, IDictionary<string, object> args) {
      
      try {
        return url.
          AppendGetParameters(httpVerb, args).
          CreateWebRequest(httpVerb).
          PostData(args).
          ReadResponse();
      }
      catch (WebException ex) {
        throw new GraphException(WebExceptionMessage, ex);
      }
    }

    static Uri AppendGetParameters(this Uri url, HttpVerb httpVerb, IDictionary<string, object> args) {

      if (httpVerb == HttpVerb.Post) {
        return url;
      }

      if (args.Keys.Any()) {
        return new Uri(String.Concat(url, QuerySeparator, args.ToQueryString()));
      }

      return url;
    }

    /// <summary>
    /// Creates <see cref="HttpWebRequest"/> from URI and HTTP verb.
    /// </summary>
    /// <param name="url">Request URI.</param>
    /// <param name="httpVerb">HTTP verb.</param>
    /// <returns></returns>
    public static HttpWebRequest CreateWebRequest(this Uri url, HttpVerb httpVerb) {

      var request = WebRequest.Create(url) as HttpWebRequest;

      request.SetHttpMethod(httpVerb);
      request.AllowAutoRedirect = true;
      request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
      request.UserAgent = UserAgent;

      return request;
    }

    static void SetHttpMethod(this HttpWebRequest request, HttpVerb httpVerb) {
      switch (httpVerb) {
        case HttpVerb.Get:
          request.Method = WebRequestMethods.Http.Get;
          break;
        case HttpVerb.Post:
          request.Method = WebRequestMethods.Http.Post;
          break;
        case HttpVerb.Delete:
          request.Method = Delete;
          break;
      }
    }

    /// <summary>
    /// Creates <see cref="Uri"/> instance from string URL.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static Uri ToUri(this string url) {
      return new Uri(url);
    } 

    /// <summary>
    /// Creates <see cref="Uri"/> instance from string URL and parameters.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static Uri ToUri(this string url, IDictionary<string, object> args) {
      return url.ToUri().
        AppendGetParameters(HttpVerb.Get, args);
    }
  }
}
