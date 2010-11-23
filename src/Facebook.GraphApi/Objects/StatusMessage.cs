namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class StatusMessage {

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("from")]
    public IdNamePair From { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }
  }
}
