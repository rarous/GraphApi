using System;
using Newtonsoft.Json;

namespace Facebook.GraphApi.Objects {

  public class User {

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("link")]
    public string Link { get; set; }

    [JsonProperty("about")]
    public string About { get; set; }

    [JsonProperty("birthday")]
    public DateTime? Birthday { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("website")]
    public string Website { get; set; }

    [JsonProperty("hometown")]
    public string HomeTown { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("verified")]
    public bool Verified { get; set; }
    
    public override string ToString() {
      return Name;
    }

    public string GetPictureUrl(PictureType type) {
      return String.Concat(Graph.Url, "/", Id, "/picture?type=", type.ToString().ToLower());
    }
  }
}

