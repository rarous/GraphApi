namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Link : IdNamePair {

    [JsonProperty("from")]
    public IdNamePair From { get; set; }

    [JsonProperty("link")]
    public string Url { get; set; }

    [JsonProperty("caption")]
    public string Caption { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }
  }
}

