namespace Facebook.GraphApi.Objects {

  using System;
  using Newtonsoft.Json;

  public class Page : IdNamePair {
    
    [JsonProperty("category")]
    public string Category { get; set; }
  }
}