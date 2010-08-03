using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Objects {

  public class Location {

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
  }
}
