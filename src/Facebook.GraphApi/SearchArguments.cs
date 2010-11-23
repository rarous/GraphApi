namespace Facebook.GraphApi {

  using System;
  using System.Collections.Generic;

  public class SearchArguments {

    public string Query { get; set; }
    public string Type { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }
    public DateTime? Since { get; set; }
    public DateTime? Until { get; set; }

    public IDictionary<string, object> ToDictionary() {
      return new Dictionary<string, object> {
        { "q", Query },
        { "type", Type },
        { "limit", Limit },
        { "offset", Offset },
        { "since", Since },
        { "until", Until },
      };
    }
  }
}
