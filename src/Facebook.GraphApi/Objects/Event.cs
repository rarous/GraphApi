namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Event : IdNamePair {

    [JsonProperty("owner")]
    public IdNamePair Owner { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("start_time")]
    public DateTime? StartTime { get; set; }

    [JsonProperty("end_time")]
    public DateTime? EndTime { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("venue")]
    public Address Venue { get; set; }

    [JsonProperty("privacy")]
    public Privacy Privacy { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }
  }
}

