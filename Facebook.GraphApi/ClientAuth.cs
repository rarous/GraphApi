using System;
using System.Web;

namespace Facebook.GraphApi {

  public class ClientAuth : IAuthentication {

    const string AccessTokenKey = "\"access_token";
    const string FacebookCookiePrefix = "fbs_";
    const string UidKey = "uid";

    readonly string clientId;
    readonly HttpContextBase httpContext;

    /// <summary>
    /// Initializes a new instance of the ClientAuth class.
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="httpContext"></param>
    public ClientAuth(string clientId, HttpContextBase httpContext) {

      if (httpContext == null) {
        throw new ClientAuthException("Client authentication can be used only on web applications.");
      }

      this.clientId = clientId;
      this.httpContext = httpContext;
    }

    public string GetAccessToken() {

      var fbCookie = GetFacebookCookie();

      return fbCookie[AccessTokenKey];
    }

    public long GetUserId() {

      var fbCookie = GetFacebookCookie();

      return Int64.Parse(fbCookie[UidKey]);
    }

    private HttpCookie GetFacebookCookie() {

      string cookieName = FacebookCookiePrefix + clientId;
      HttpRequestBase request = httpContext.Request;
      HttpCookie cookie = request.Cookies[cookieName];

      if (cookie == null) {
        throw new ClientAuthException("Can not find user cookie.");
      }

      return cookie;
    }
  }
}
