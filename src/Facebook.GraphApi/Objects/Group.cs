namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Group : IdNamePair {

    [JsonProperty("owner")]
    public IdNamePair Owner { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("venue")]
    public Address Venue { get; set; }

    [JsonProperty("privacy")]
    public Privacy Privacy { get; set; }

    [JsonProperty("updated_time")]
    public DateTime Updated { get; set; }
  }
}
