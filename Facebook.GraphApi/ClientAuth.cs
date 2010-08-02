using System;
using System.Web;

namespace Facebook.GraphApi {

  public class ClientAuth : IAuthentication {

    const string AccessTokenKey = "\"access_token";
    private const string FacebookCookiePrefix = "fbs_";

    readonly string clientId;
    readonly HttpContextBase httpContext;

    /// <summary>
    /// Initializes a new instance of the ClientAuth class.
    /// </summary>
    /// <param name="clientId"></param>
    /// <param name="httpContext"></param>
    public ClientAuth(string clientId, HttpContextBase httpContext) {
      this.clientId = clientId;
      this.httpContext = httpContext;
    }

    public string Authorize() {

      if (httpContext == null) {
        throw new ClientAuthException("Client authentication can be used only on web applications.");
      }

      HttpCookie fbCookie = GetFacebookCookie();
      if (fbCookie == null) {
        throw new ClientAuthException("Can not find user cookie.");
      }

      return fbCookie[AccessTokenKey];
    }

    private HttpCookie GetFacebookCookie() {

      HttpRequestBase request = httpContext.Request;
      string cookieName = FacebookCookiePrefix + clientId;

      return request.Cookies[cookieName];
    }
  }
}
