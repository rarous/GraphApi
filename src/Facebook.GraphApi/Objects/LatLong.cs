using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Objects {

  public class LatLong {

    [JsonProperty("latitude")]
    public string Latitude { get; set; }

    [JsonProperty("longitude")]
    public string Longitude { get; set; }
  }
}
