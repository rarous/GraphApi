namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class IdNamePair {

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    public override string ToString() {
      return Name;
    }
  }
}
