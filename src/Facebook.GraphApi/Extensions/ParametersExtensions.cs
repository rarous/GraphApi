namespace Facebook.GraphApi {

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;

  public static class ParametersExtensions {

    const string AccessTokenKey = "access_token";
    const string Display = "display";
    const string Scope = "scope";
    const string Type = "type";

    public static IDictionary<string, object> AddAccessToken(this IDictionary<string, object> args, string accessToken) {
      if (String.IsNullOrEmpty(accessToken) == false) {
        args[AccessTokenKey] = accessToken;
      }
      return args;
    }

    public static IDictionary<string, object> AddAuthorizationType(this IDictionary<string, object> args, AuthorizationType type) {
      if (type != AuthorizationType.None) {
        args.Add(Type, type.ToString().ToUndescoreCasing());
      }
      return args;
    }

    public static IDictionary<string, object> AddDisplayType(this IDictionary<string, object> args, DisplayType display) {
      if (display != DisplayType.Page) {
        args.Add(Display, display.ToString().ToUndescoreCasing());
      }
      return args;
    }

    public static IDictionary<string, object> AddScope(this IDictionary<string, object> args, Permissions scope) {
      if (scope != Permissions.None) {
        args.Add(Scope, scope.ToString().ToUndescoreCasing());
      }
      return args;
    }

    public static string ToUndescoreCasing(this string text) {

      var query = from l in text.Let(t => 
                    t.Zip(t.Skip(1), (prev, cur) => new {
                      ch = cur,
                      isCamel = Char.IsUpper(cur) && !Char.IsWhiteSpace(prev),
                    }))
                  where !Char.IsWhiteSpace(l.ch)
                  select l.isCamel ? "_" + l.ch : l.ch.ToString();

      return String.Concat(text.First(), String.Join(String.Empty, query.ToArray())).ToLower();
    }

    public static IDictionary<string, object> EnsureArguments(this IDictionary<string, object> args) {
      if (args == null) {
        return new Dictionary<string, object>();
      }
      return args;
    }

    public static string ToQueryString(this IDictionary<string, object> parameters) {
      const string PairsSeparator = "&";
      return String.Join(PairsSeparator, parameters.Select(NameValuePair).ToArray());
    }

    static string NameValuePair(KeyValuePair<string, object> pair) {
      const string KeyValueSeparator = "=";
      string value = pair.Value != null ? pair.Value.ToString() : String.Empty;
      return String.Concat(pair.Key, KeyValueSeparator, HttpUtility.UrlEncode(value));
    }

  }
}
