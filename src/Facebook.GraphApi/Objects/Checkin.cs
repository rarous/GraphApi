using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Objects {

  public class Checkin {

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("from")]
    public IdNamePair From { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("coordinates")]
    public LatLong Coordinates { get; set; }

    [JsonProperty("application")]
    public IdNamePair Application { get; set; }

    [JsonProperty("created_time")]
    public DateTime Created { get; set; }
  }
}
