namespace Facebook.GraphApi {

  using System;
  using System.Linq;
  using System.Web;

  /// <summary>
  /// Client authentication for use with JS SDK.
  /// </summary>
  /// <remarks>
  /// To work properly, you need to initialize JD SDK with <c>status</c> and <c>cookie</c>
  /// parameters set to <c>true</c>.
  /// <para>
  /// <c>FB.init({ appId: 'your app id', status: true, cookie: true });</c>
  /// </para>
  /// </remarks>
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

    /// <summary>
    /// Gets access token of authenticated user.
    /// </summary>
    /// <returns></returns>
    public string GetAccessToken() {

      HttpCookie fbCookie = GetFacebookCookie();

      return HttpUtility.UrlDecode(fbCookie[AccessTokenKey]);
    }

    /// <summary>
    /// Gets Facebook's UID of authenticated user.
    /// </summary>
    /// <returns></returns>
    public long GetUserId() {

      HttpCookie fbCookie = GetFacebookCookie();
      string userIdString = ParseUserId(fbCookie[UidKey]);

      return Int64.Parse(userIdString);
    }

    static string ParseUserId(string uidValue) {
      // Facebook cookie vas dirty values in quotes etc. We need only numbers.
      return new String(uidValue.Where(Char.IsNumber).ToArray());
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

    /// <summary>
    /// Checks that user is authenticated.
    /// </summary>
    /// <returns>Returns <c>true</c> if user is authenticated. Otherwise <c>false</c>.</returns>
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
