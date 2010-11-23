namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Album : IdNamePair {

    [JsonProperty("from")]
    public IdNamePair From { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("created_time")]
    public DateTime Created { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }
  }
}
