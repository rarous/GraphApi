namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Address : LatLong {

    [JsonProperty("street")]
    public string Street { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("zip")]
    public string Zip { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }
  }
}
