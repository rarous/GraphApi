using System;

namespace Facebook.GraphApi.Objects {

  public static class GraphExtensions {

    public static User GetUser(this Graph graphApi, long uid) {
      return graphApi.Get(uid).Deserialize<User>();
    }

    public static User GetUser(this Graph graphApi) {
      return graphApi.Get("/me").Deserialize<User>();
    }
  }
}
