using System;
using System.Linq;
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

      return HttpUtility.UrlDecode(fbCookie[AccessTokenKey]);
    }

    public long GetUserId() {

      var fbCookie = GetFacebookCookie();

      return Int64.Parse(new String(fbCookie[UidKey].Where(Char.IsNumber).ToArray()));
    }

    HttpCookie GetFacebookCookie() {

      string cookieName = FacebookCookiePrefix + clientId;
      HttpRequestBase request = httpContext.Request;
      HttpCookie cookie = request.Cookies[cookieName];

      if (cookie == null) {
        throw new ClientAuthException("Cannot find user cookie.");
      }

      return cookie;
    }

    public bool IsAuthenticated() {
      try {
        return String.IsNullOrEmpty(GetAccessToken()) == false;
      }
      catch (ClientAuthException) {
        return false;
      }
    }
  }
}