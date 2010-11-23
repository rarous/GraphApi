namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Post {

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

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

    [JsonProperty("picture")]
    public string Picture { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("icon")]
    public string Icon { get; set; }

    [JsonProperty("attribution")]
    public string Attribution { get; set; }

    [JsonProperty("actions")]
    public string[] Actions { get; set; }

    [JsonProperty("likes")]
    public int Likes { get; set; }

    public override string ToString() {
      return Message;
    }
  }
}
