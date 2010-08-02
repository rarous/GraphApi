using System;
using System.Collections.Generic;
using System.Linq;

namespace Facebook.GraphApi {

  public static class ParametersExtensions {

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
  }
}
