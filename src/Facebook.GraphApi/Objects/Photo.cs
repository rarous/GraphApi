using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Objects {

  public class Photo : IdNamePair {

    [JsonProperty("from")]
    public IdNamePair From { get; set; }

    [JsonProperty("picture")]
    public string Picture { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("created_time")]
    public DateTime Created { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }
  }
}
