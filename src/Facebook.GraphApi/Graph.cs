using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Facebook.GraphApi {

  public class Graph {

    public const string Url = "https://graph.facebook.com/";
    const string SearchPath = "/search";

    static Uri baseUri = new Uri(Graph.Url);

    readonly string accessToken;

    /// <summary>
    /// Initializes a new instance of the Graph class with anonymous access.
    /// </summary>
    public Graph()
      : this(null) {
    }

    /// <summary>
    /// Initializes a new instance of the Graph class.
    /// </summary>
    /// <param name="accessToken"></param>
    public Graph(string accessToken) {
      this.accessToken = accessToken;
    }

    public string AccessToken {
      get {
        return accessToken;
      }
    }

    /// <summary>
    /// Makes a Facebook Graph API GET request.
    /// </summary>
    /// <param name="objectId">Facebook ID of requested object.</param>
    public JObject Get(long objectId) {
      return Get("/" + objectId);
    }

    /// <summary>
    /// Makes a Facebook Graph API GET request.
    /// </summary>
    /// <param name="relativePath">The path for the call, e.g. /username</param>
    public JObject Get(string relativePath) {

      return Call(relativePath, HttpVerb.Get, null);
    }

    /// <summary>
    /// Makes a Facebook Graph API GET request.
    /// </summary>
    /// <param name="relativePath">The path for the call, e.g. /username</param>
    /// <param name="args">A dictionary of key/value pairs that will get passed as query arguments.</param>
    public JObject Get(string relativePath, IDictionary<string, object> args) {

      return Call(relativePath, HttpVerb.Get, args);
    }

    /// <summary>
    /// Makes a Facebook Graph API DELETE request.
    /// </summary>
    /// <param name="relativePath">The path for the call, e.g. /username</param>
    public JObject Delete(string relativePath) {

      return Call(relativePath, HttpVerb.Delete, null);
    }

    /// <summary>
    /// Makes a Facebook Graph API POST request.
    /// </summary>
    /// <param name="relativePath">The path for the call, e.g. /username</param>
    /// <param name="args">A dictionary of key/value pairs that
    /// will get passed as query arguments. These determine
    /// what will get set in the graph API.</param>
    public JObject Post(string relativePath, IDictionary<string, object> args) {

      return Call(relativePath, HttpVerb.Post, args);
    }

    /// <summary>
    /// Searches Facebook Graph objects.
    /// </summary>
    /// <param name="args">Search arguments.</param>
    /// <returns></returns>
    public JObject Search(SearchArguments args) {

      return Call(SearchPath, HttpVerb.Get, args.ToDictionary());
    }

    protected virtual JObject Call(string relativePath, HttpVerb httpVerb, IDictionary<string, object> args) {

      var arguments = args.
        EnsureArguments().
        AddAccessToken(AccessToken);

      return GetRequestUri(relativePath).
        MakeJsonRequest(httpVerb, arguments).
        HandleError();
    }

    static Uri GetRequestUri(string relativePath) {
      return new Uri(baseUri, relativePath);
    }
  }
}