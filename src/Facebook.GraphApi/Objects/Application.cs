namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Application : IdNamePair {

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("category")]
    public string Category { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }
  }
}
