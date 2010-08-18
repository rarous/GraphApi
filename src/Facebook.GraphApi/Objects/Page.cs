using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Objects {

  public class Page : IdNamePair {
    
    [JsonProperty("category")]
    public string Category { get; set; }
  }
}