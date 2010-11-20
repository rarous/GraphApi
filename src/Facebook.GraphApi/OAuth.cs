using System;
using System.Collections.Generic;
using System.Web;

namespace Facebook.GraphApi {

  public class OAuth : IAuthentication {

    const string AccessToken = "access_token";
    const string AccessTokenUrl = "https://graph.facebook.com/oauth/access_token";
    const string AuthorizationCode = "authorization_code";
    const string AuthorizeUrl = "https://graph.facebook.com/oauth/authorize";
    const string ClientIdKey = "client_id";
    const string ClientSecretKey = "client_secret";
    const string CodeKey = "code";
    const string GrantTypeKey = "grant_type";
    const string RedirectUriKey = "redirect_uri";
    const string ResponseTypeKey = "response_type";

    readonly string clientId;
    readonly string clientSecret;
    readonly HttpContextBase httpContext;

    public OAuth(string clientId, string clientSecret, HttpContextBase httpContext) {
      this.clientId = clientId;
      this.clientSecret = clientSecret;
      this.httpContext = httpContext;
    }

    public DisplayType Display { get; set; }
    public Permissions Scope { get; set; }
    public AuthorizationType Type { get; set; }

    public string GetAccessToken() {
      return GetAccessToken(null);
    }

    public string GetAccessToken(string redirectUrl) {

      if (String.IsNullOrEmpty(redirectUrl)) {
        redirectUrl = GetRedirectUrl();
      }

      var code = GetAuthorizationCode(redirectUrl);

      return GetAccessToken(code, redirectUrl);
    }

    string GetRedirectUrl() {

      string redirectUrl = httpContext.Request.Url.ToString();
      if (redirectUrl.Contains("?")) {
        redirectUrl = redirectUrl.Substring(0, redirectUrl.IndexOf('?'));
      }

      return redirectUrl;
    }

    string GetAuthorizationCode(string redirectUrl) {

      var code = httpContext.Request[CodeKey];
      if (String.IsNullOrEmpty(code)) {
        RequestAuthorizationCode(redirectUrl);
      }

      return code;
    }

    void RequestAuthorizationCode(string redirectUrl) {

      var args = new Dictionary<string, object> {
        { ResponseTypeKey, CodeKey },
        { ClientIdKey, clientId },
        { RedirectUriKey, redirectUrl },
      };

      args.AddScope(Scope).
        AddDisplayType(Display).
        AddAuthorizationType(Type);

      var requestUrl = AuthorizeUrl.ToUri(args);

      httpContext.Response.Redirect(requestUrl.ToString(), true);
    }

    string GetAccessToken(string code, string redirectUrl) {

      var args = new Dictionary<string, object> {
        { GrantTypeKey, AuthorizationCode },
        { ClientIdKey, clientId },
        { ClientSecretKey, clientSecret },
        { CodeKey, code },
        { RedirectUriKey, redirectUrl },
      };

      var response = AccessTokenUrl.ToUri().
        MakeNameValueRequest(HttpVerb.Get, args);

      return response[AccessToken];
    }

    public bool IsAuthenticated() {
      try {
        return String.IsNullOrEmpty(GetAccessToken()) == false;
      }
      catch (OAuthException) {
        return false;
      }
    }
  }
}
