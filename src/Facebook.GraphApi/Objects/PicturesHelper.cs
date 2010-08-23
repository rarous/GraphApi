using System;

namespace Facebook.GraphApi.Objects {

  public static class PicturesHelper {

    public static string GetImageUrl(object id, PictureType type) {

      return String.Concat(Graph.Url, "/", id, "/picture?type=", type.ToString().ToLower());
    }
  }
}
