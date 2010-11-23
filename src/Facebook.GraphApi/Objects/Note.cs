namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Note {

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("from")]
    public IdNamePair From { get; set; }

    [JsonProperty("subject")]
    public string Subject { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }

    [JsonProperty("created_time")]
    public DateTime Created { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }

    public override string ToString() {
      return Subject;
    }
  }
}
