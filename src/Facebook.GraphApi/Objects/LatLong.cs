namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class LatLong {

    [JsonProperty("latitude")]
    public string Latitude { get; set; }

    [JsonProperty("longitude")]
    public string Longitude { get; set; }
  }
}
