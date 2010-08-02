using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Facebook.GraphApi {

  public class OAuth {

    const string AuthorizeUrl = "https://graph.facebook.com/oauth/authorize";
    const string AccessTokenUrl = "https://graph.facebook.com/oauth/access_token";

    readonly string clientId;
    readonly string clientSecret;
    readonly HttpContextBase httpContext;

    public OAuth(string clientId, string clientSecret, HttpContextBase httpContext) {
      this.clientId = clientId;
      this.clientSecret = clientSecret;
      this.httpContext = httpContext;
    }

    public string Authorize(string redirectUrl) {
      if (String.IsNullOrEmpty(redirectUrl)) {
        redirectUrl = httpContext.Request.Url.ToString();
      }

      var code = GetAuthorizationCode(redirectUrl);

      return GetAccessToken(code, redirectUrl);
    }

    private string GetAuthorizationCode(string redirectUrl) {
      var code = httpContext.Request["code"];
      if (String.IsNullOrEmpty(code)) {
        RequestAuthorizationCode(redirectUrl);
      }
      return code;
    }

    private void RequestAuthorizationCode(string redirectUrl) {

      var args = new Dictionary<string, object> {
				{ "response_type", "code" },
				{ "client_id", clientId },
				{ "redirect_url", redirectUrl },
			};

      var requestUrl = AuthorizeUrl.ToUri(args);

      httpContext.Response.Redirect(requestUrl.ToString(), true);
    }

    private string GetAccessToken(string code, string redirectUrl) {

      var args = new Dictionary<string, object> {
				{ "grant_type", "authorization_code" },
				{ "client_id", clientId },
				{ "client_secret", clientSecret },
				{ "code", code },
				{ "redirect_url", redirectUrl },
			};

      var response = AccessTokenUrl.ToUri().
        MakeJsonRequest(HttpVerb.Get, args);

      JToken error;
      if (response.TryGetValue("error", out error)) {
        throw new OAuthException(error.Value<string>());
      }

      return response.Value<string>("access_token");
    }
  }
}
